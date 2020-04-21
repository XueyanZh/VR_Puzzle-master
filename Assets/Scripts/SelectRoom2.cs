using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRoom2 : MonoBehaviour
{
    public GameObject panel;
    public GameObject YNpanel;
    public Text prompt;
    public GameObject fuzhou;
    string nowselected;
    public GameObject doors;


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
        if (Physics.Raycast(ray, out hit))
        {

            var selection = hit.transform;
            if (selection.CompareTag("NotSelectable"))
            {
                if (Input.GetMouseButton(0))
                {
                    nowselected = selection.name;
                    print("has flag");
                    panel.SetActive(true);
                    prompt.text = "This is the room I just left.";
                    doors.GetComponent<AudioSource>().Play();

                }

            }
            else if (selection.CompareTag("Selectable"))
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
                        prompt.text = "The doors in this room are still locked.";
                        doors.GetComponent<AudioSource>().Play();
                    }
                    else if (GameController.flag1 == 1)
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
                    fuzhou.SetActive(false);
                    YNpanel.SetActive(false);
                }
                else if (GameController.flag1 == 1)
                {
                    fuzhou.SetActive(true);
                    //selectionRender.material = hoverColor;
                }

            }
            else if (selection.CompareTag("table2"))
            {

                fuzhou.SetActive(false);
                print("table");
                var selectionRender = selection.GetComponent<Renderer>();
                if (Input.GetMouseButton(0))
                {
                    nowselected = selection.name;
                    
                    selection.GetComponent<AudioSource>().Play();

                    //selectionRender.material = clickColor;

                    //CharToMove.transform.position = Destination.position;
                }

            }
            else
            {
                fuzhou.SetActive(false);
                YNpanel.SetActive(false);
                panel.SetActive(false);
                prompt.text = "";
                print("is not selectable");

            }

        }

    }
}
