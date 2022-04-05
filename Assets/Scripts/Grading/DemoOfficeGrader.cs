using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoOfficeGrader : MonoBehaviour
{
    /* Points Breakdown for this room:
     * Workstation: (5 total)
     *  (+ 1) if desk is professionally colored
     *  (+ 1) if desk is not near a bookshelf
     *  (+ 1) if desk is near a chair
     *  (+ 1) if a chair is professionally colored
     *  (+ 1) if a chair is the same color as the desk
     * Library: (3 total)
     *  (+ 1) if there is a colorful bookshelf
     *  (+ 1) if there is a colorful chair
     *  (+ 1) if there is more than one colorful chair
     * Counts: (2 total)
     *  (+ 1) if there is more than 3 but less than 8 furniture items
     *  (+ 1) if there is at least one chair, one desk, and one bookshelf
     */

    [SerializeField] private Furniture[] FurnitureList;
    [SerializeField] private List<Furniture> Desks;
    [SerializeField] private List<Furniture> Chairs;
    [SerializeField] private List<Furniture> Bookshelves;
    [SerializeField] private List<Furniture> Sofas;
    [SerializeField] private bool[] WorkstationCriteria, LibraryCriteria, CountCriteria; // these track the requirements listed in the comments
    [SerializeField] private GameObject GradingPanel;
    [SerializeField] private GameObject CheckboxLayout;
    [SerializeField] private TMP_Text ScoreTextBox;
    [SerializeField] private Timer GameTimer;
    [SerializeField] private GameObject CriterionPrefab;

    public void GradeDemoOfficeRoom()
    {
        FurnitureList = FindObjectsOfType<Furniture>();
        foreach (Furniture furni in FurnitureList)
        {
            if (furni.GetLabel() == "Table" || furni.GetLabel() == "Desk")
            {
                Desks.Add(furni);
            }
            else if (furni.GetLabel() == "Chair")
            {
                Chairs.Add(furni);
            }
            else if (furni.GetLabel() == "Bookshelf")
            {
                Bookshelves.Add(furni);
            }
            else if (furni.GetLabel() == "Sofa" || furni.GetLabel() == "Loveseat")
            {
                Sofas.Add(furni);
            }
        }
        int timeBonus = CalculateTimeBonus();
        int finalScore = WorkstationCheck() + LibraryCheck() + CountCheck() + timeBonus;
        // old textbox code
        //string gradingRubric = 
        //    $"Grading: \n\n" +
        //    $"(1 pt) Professional color chosen for desk: {WorkstationCriteria[0]} \n" +
        //    $"(1 pt) Desk and library separated: {WorkstationCriteria[1]} \n" +
        //    $"(1 pt) Desk has a chair nearby: {WorkstationCriteria[2]} \n" +
        //    $"(1 pt) Professional color chosen for chair: {WorkstationCriteria[3]} \n" +
        //    $"(1 pt) Desk and chair colors match: {WorkstationCriteria[4]} \n\n" +
        //    $"(1 pt) Exciting bookshelf color chosen: {LibraryCriteria[0]} \n" +
        //    $"(1 pt) One vibrant comfortable seat in room: {LibraryCriteria[1]} \n" +
        //    $"(1 pt) Multiple vibrant comfortable seat in room: {LibraryCriteria[2]} \n\n" +
        //    $"(1 pt) Between 4 to 7 pieces of furniture: {CountCriteria[0]} \n" +
        //    $"(1 pt) At least 1 table, chair, and bookshelf: {CountCriteria[1]} \n\n" +
        //    $"(5 pt) Time Bonus: {timeBonus} \n\n" +
        //    $"Total Score: {finalScore}/15";
        //TextBox.text = gradingRubric;

        // new checkboxes code
        string[] workstationDescriptions =
        {
            "Professional color chosen for desk (1 pt)",
            "Desk and library separated (1 pt)",
            "Desk has a chair nearby (1 pt)",
            "Professional color chosen for chair (1 pt)",
            "Desk and chair colors match (1 pt)",
        };
        string[] libraryDescriptions = 
        {
            "Exciting bookshelf color chosen (1 pt)",
            "One vibrant comfortable seat in room (1 pt)",
            "Multiple vibrant comfortable seat in room (1 pt)",
        };
        string[] countCriteria =
        {
            "Between 4 to 7 pieces of furniture (1 pt)",
            "At least 1 table, chair, and bookshelf (1 pt)",
        };

        for (int item = 0; item < WorkstationCriteria.Length + LibraryCriteria.Length + CountCriteria.Length; item++)
        {
            if (item < WorkstationCriteria.Length)
            {
                CreateToggle(workstationDescriptions[item], WorkstationCriteria[item]);
            }
            else if (item < WorkstationCriteria.Length + LibraryCriteria.Length)
            {
                int index = item - WorkstationCriteria.Length;
                CreateToggle(libraryDescriptions[index], LibraryCriteria[index]);
            }
            else
            {
                int index = item - WorkstationCriteria.Length - LibraryCriteria.Length;
                CreateToggle(countCriteria[index], CountCriteria[index]);
            }
        }

        string scoreMessage = $"Time Bonus (5 pts): {timeBonus}\nTotal Score: {finalScore}/15";
        ScoreTextBox.text = scoreMessage;

        GradingPanel.gameObject.SetActive(true);
    }

    private void CreateToggle(string message, bool value)
    {
        // creating the toggle as a child of the layout window
        GameObject toggleObject = Instantiate(CriterionPrefab, CheckboxLayout.transform);
        // initializing the text
        Criterion criterion = toggleObject.GetComponent<Criterion>();
        criterion.SetState(message, value);
    }

    private int WorkstationCheck()
    {
        int maxScore = 0;
        WorkstationCriteria = new bool[] { false, false, false, false, false };

        foreach (Furniture desk in Desks)
        {
            int score = 0;
            bool[] tempCriteria = new bool[] { false, false, false, false, false };

            // check color of desk
            if (desk.GetColorName() == "orange" || desk.GetColorName() == "brown" || desk.GetColorName() == "white")
            {
                score += 1;
                tempCriteria[0] = true;
            }

            // check if bookshelf is nearby and fail if so
            bool nearbyBookshelf = false;
            foreach (Furniture bookshelf in Bookshelves)
            {
                if (Vector3.Distance(desk.transform.position, bookshelf.transform.position) < 14f)
                {
                    nearbyBookshelf = true;
                }
            }
            if (!nearbyBookshelf)
            {
                score += 1;
                tempCriteria[1] = true;
            }

            // check if the chair is nearby and the right color
            int chairMaxScore = 0;
            
            foreach (Furniture chair in Chairs)
            {
                int chairScore = 0;
                bool[] chairCriteria = new bool[] { false, false, false };

                // check if chair is near desk
                if (Vector3.Distance(desk.transform.position, chair.transform.position) < 6f)
                {
                    chairScore += 1;
                    chairCriteria[0] = true;
                }
                // check if chair is professionally colored
                if (chair.GetColorName() == "orange" || chair.GetColorName() == "brown" || chair.GetColorName() == "white")
                {
                    chairScore += 1;
                    chairCriteria[1] = true;
                }
                // check if chair color matches desk
                if (chair.GetColorName() == desk.GetColorName())
                {
                    chairScore += 1;
                    chairCriteria[2] = true;
                }
                // if the chair is the best candidate for the desk chair, overwrite the values for the grading criteria
                if (chairScore > chairMaxScore)
                {
                    tempCriteria[2] = chairCriteria[0];
                    tempCriteria[3] = chairCriteria[1];
                    tempCriteria[4] = chairCriteria[2];
                }
                chairMaxScore = Mathf.Max(chairMaxScore, chairScore);
            }
            score += chairMaxScore;

            if (score > maxScore)
            {
                WorkstationCriteria = tempCriteria;
            }
            maxScore = Mathf.Max(maxScore, score);
        }

        return maxScore;
    }

    private int LibraryCheck()
    {
        int score = 0;
        LibraryCriteria = new bool[] { false, false, false };

        // check for a colorful bookshelf
        bool colorfulBookshelf = false;
        foreach (Furniture bookshelf in Bookshelves)
        {
            if (bookshelf.GetColorName() == "red" || bookshelf.GetColorName() == "yellow" || bookshelf.GetColorName() == "green" || bookshelf.GetColorName() == "blue" || bookshelf.GetColorName() == "purple")
            {
                colorfulBookshelf = true;
            }
        }
        if(colorfulBookshelf)
        {
            score += 1;
            LibraryCriteria[0] = true;
        }

        // look for at most two colorful chairs, and add either zero, one, or two points based on number of chairs
        int seats = 0;
        foreach (Furniture seat in Sofas)
        {
            if (seat.GetColorName() == "red" || seat.GetColorName() == "yellow" || seat.GetColorName() == "green" || seat.GetColorName() == "blue" || seat.GetColorName() == "purple")
            {
                seats += 1;
                if (seats == 1)
                {
                    LibraryCriteria[1] = true;
                }
                else if (seats > 1)
                {
                    LibraryCriteria[2] = true;
                }
            }
        }
        score += Mathf.Min(seats, 2);

        return score;
    }

    private int CountCheck()
    {
        int score = 0;
        CountCriteria = new bool[] { false, false };

        // check total number of furniture items
        if (FurnitureList.Length > 3 && FurnitureList.Length < 8)
        {
            score += 1;
            CountCriteria[0] = true;
        }

        // check if there is a desk, chair, and bookshelf
        if (Desks.Count > 0 && Chairs.Count > 0 && Bookshelves.Count > 0)
        {
            score += 1;
            CountCriteria[1] = true;
        }

        return score;
    }

    public void ClosePanel()
    {
        GradingPanel.SetActive(false);

        // clear out previous criteria from layout
        Criterion[] criteria = CheckboxLayout.GetComponentsInChildren<Criterion>();
        foreach (Criterion criterion in criteria)
        {
            Destroy(criterion.gameObject);
        }

        // clear out lists of furniture
        Desks = new List<Furniture>();
        Chairs = new List<Furniture>();
        Bookshelves = new List<Furniture>();
        Sofas = new List<Furniture>();
    }

    //public void DisplayInstructions()
    //{
    //    GradingPanel.SetActive(true);
    //    TextBox.text = "(this is temporary - in reality, you'd talk to the client)\n\n" +
    //        "Your client wants to create a nice office room that he can both work and relax in.\n\n " +
    //        "He wants the room to have two major sections: a work station where he can work without distraction, " +
    //        "and a personal library for taking breaks, relaxing, and spending time with his wife and son after work.\n\n" +
    //        "He wants the work station to look professional for his video conferences and wants the library to stand out and use exciting colors.";
    //}

    private int CalculateTimeBonus()
    {
        if (Mathf.Floor(GameTimer.GetTimerValue()) < 60)
        {
            return 5;
        }
        if (Mathf.Floor(GameTimer.GetTimerValue()) < 90)
        {
            return 4;
        }
        if (Mathf.Floor(GameTimer.GetTimerValue()) < 120)
        {
            return 3;
        }
        if (Mathf.Floor(GameTimer.GetTimerValue()) < 150)
        {
            return 2;
        }
        if (Mathf.Floor(GameTimer.GetTimerValue()) < 180)
        {
            return 1;
        }
        return 0;
    }
}
