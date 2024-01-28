using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Polotto : MonoBehaviour
{
    public GameObject myCacca;
    public GameObject testoPolotto;
    private float timer=0.0f;
    
    public string[] jokesArray = new string[]
    {
        "- What kind of dog does Dracula have?\n- A bloodhound!",
        "- Why do dogs make terrible dance partners?\n- Because they have two left feet!",
        "- What happened when the dog went\n to the flea circus?\n- He stole the show!",
        "- What do dogs eat for breakfast?\n- Pooched eggs!",
        "- What dog keeps the best time?\n- A watchdog!",
        "- What do a dog and a cellphone\n have in common?\n- Both have collar ID!",
        "- What kind of dog doesn’t bark?\n- A hushpuppy!",
        "- What kind of dog loves to\n take bubble baths?\n- A shampoodle!",
        "- What do you call a cold canine?\n- A chili dog!",
        "- What do you call a frozen dog?\n- A pupsicle!",
        "- What do you give a dog with a fever?\n- Mustard! It’s the best thing for a hot dog!",
        "- What do you get when you cross\n a dog with a calculator?\n- A best friend you can count on!",
        "- What did the Dalmatian\n say after his meal?\n- That really hit the spot!",
        "- What do you call a dog that can do magic?\n- A Labracadabrador!",
        "- Why did the cowboy get a\n wiener dog?\n- He wanted to get a long, little doggie!",
        "- Are dogs good at science?\n- Well, labs are!",
        "- What did the dog study at college?\n- Bark-eology!",
        "- What did the dog say to the sandpaper?\n- Ruff!",
        "- What do you do if your dog\n chews up your dictionary?\n- Take the words out of his mouth!",
        "- What did one flea say to the other?\n- Should we walk or take the dog?",
        "- Where do dogs hate to shop?\n- The flea market!",
        "- Where do you put barking dogs?\n- In a barking lot!",
        "- Why couldn’t the dog\n get the apple?\n- He was barking up the wrong tree!",
        "- What trick did the loaf\n of bread teach the dog?\n- Roll over!",
        "- What kind of tree has the best bark?\n- A dogwood!",
        "- What did the fish name his dog?\n- Gill!",
        "- Where should you go if\n your dog is missing?\n- The lost and hound!",
        "- Why do dogs float?\n- Because they’re good buoys!",
        "- Which dog breed is guaranteed\n to laugh at all of your jokes?\n- A Chi-ha-ha!"
    };

    void Awake(){
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cacca"))
        {
            GetComponent<Collider2D>().enabled = false;
            myCacca.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer>5){
            
            int randomIndex = Random.Range(0, jokesArray.Length);
            string selectedJoke = jokesArray[randomIndex];
            testoPolotto.GetComponent<TextMesh>().text=selectedJoke;
            timer=0;
        }
    }


    static string InsertNewlines(string input, int maxSubstringLength)
    {
        int index = maxSubstringLength;
        while (index < input.Length)
        {
            while (index > 0 && input[index] != ' ')
            {
                index--;
            }

            if (index == 0)
            {
                index = maxSubstringLength; // Couldn't find a space, break at max length
            }
            else
            {
                input = input.Substring(0, index) + "\n" + input.Substring(index + 1);
                index += maxSubstringLength;
            }
        }

        return input;
    }


}
    