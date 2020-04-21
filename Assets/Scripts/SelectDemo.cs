using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDemo : MonoBehaviour
{
    //public Material hoverColor;
    //public Material clickColor;
    //public Material normalColor;
    //private Transform SelectedItem;
    public GameObject panel;
    public GameObject YNpanel;
    public Text prompt;
    public GameObject fuzhou;
    string nowselected;
    public GameObject doors;
    public GameObject book;
    public GameObject graph;
    //public Transform Destination;
    //public GameObject CharToMove;

    // Update is called once per frame
    void Update()
    {
        //if (SelectedItem != null) {
        //    var selectionRender = SelectedItem.GetComponent<Renderer>();
        //    //selectionRender.material = normalColor;
        //    SelectedItem = null;
        //    panel.SetActive(false);
        //    prompt.text = "";
        //}

        //turn the mouse position to a world object
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {

            var selection = hit.transform;

            if (selection.CompareTag("Selectable"))
            {
                print("is selectable");
                var selectionRender = selection.GetComponent<Renderer>();
                if (Input.GetMouseButton(0))
                {
                    nowselected = selection.name;
                    if (GameController.flag1 == 0)
                    {
                        print("no flag");
                        panel.SetActive(true);
                        prompt.text = "The doors are locked by some forbidden spells. I cannot open them with my bare hands.";
                        doors.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        print("has flag");
                        panel.SetActive(true);
                        prompt.text = "Am I sure to open this door? The puppets might be dangerous on the other side.";
                        gameObject.GetComponent<AudioSource>().Play();
                        YNpanel.SetActive(true);

                    }

                    //selectionRender.material = clickColor;

                    //CharToMove.transform.position = Destination.position;
                }
                else if (selection.name != nowselected)
                {
                    book.SetActive(false);
                    graph.SetActive(false);
                    fuzhou.SetActive(false);
                    YNpanel.SetActive(false);
                }
                else if (GameController.flag1 == 1)
                {
                    fuzhou.SetActive(true);
                    //selectionRender.material = hoverColor;
                }
                
            }
            else if (selection.CompareTag("table1"))
            {

                fuzhou.SetActive(false);
                print("table");
                var selectionRender = selection.GetComponent<Renderer>();
                if (Input.GetMouseButton(0))
                {
                    nowselected = selection.name;
                    if (selection.name == "books")
                    {
                        panel.SetActive(true);
                        book.SetActive(true);
                        prompt.text = "There are some books on the table. I cannot read this language but I think these images have some meaning related to the way out.";
                    }
                    else if (selection.name == "graph")
                    {
                        panel.SetActive(true);
                        graph.SetActive(true);
                        prompt.text = "A strange disk with strange symbols...Looks like those puppets outside.";
                    }
                    else if (selection.name == "incence")
                    {
                        GameController.flag1 = 1;
                        panel.SetActive(true);
                        prompt.text = "A rune paper is pinned underneath the incence burner. I take it outside.";
                    }
                    selection.GetComponent<AudioSource>().Play();

                    //selectionRender.material = clickColor;

                    //CharToMove.transform.position = Destination.position;
                }
                else if (selection.name != nowselected)
                {
                    book.SetActive(false);
                    graph.SetActive(false);
                    fuzhou.SetActive(false);
                    YNpanel.SetActive(false);
                }

            }
            else
            {
                book.SetActive(false);
                graph.SetActive(false);
                fuzhou.SetActive(false);
                YNpanel.SetActive(false);
                panel.SetActive(false);
                prompt.text = "";
                print("is not selectable");

            }

        }
        
    }
}
