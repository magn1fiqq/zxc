using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Game : MonoBehaviour
{
    public static string[] wordsArray = File.ReadAllLines(@"D:\study\letters\Assets\SpritesAndText\words.txt"); // 1. Чтение слов из файла
    public string[] WordsMixArray;
    public string word;
    public string chek;
    public GameObject letter;
    public Transform Hand;
    public Image Logo;
    bool isDone;
    int count = 0;
    int arrayIndex = 0;
    public int score = 0;

    void Start() // Выполнение пунктов 1-4
    {
        WordsMixArray = Shuffle(wordsArray);

        word = WordsMixArray[arrayIndex];
        Create(word);

    }

    private void LateUpdate() // Выполнение пунктов 5-6
    {
        if (isDone)
        {
            ChekLetters();
        }
        else
        {

            Create(word);
            
        }
    }

    string[] Shuffle(string[] nums) // 2. Перемешивание слов
    {
        for (int i = 0; i < nums.Length; i++)
        {
            string currentValue = nums[i];
            int randomIndex = Random.Range(i, nums.Length);
            nums[i] = nums[randomIndex];
            nums[randomIndex] = currentValue;
        }
        return nums;
    }

    public char[] LetterShuffle(char[] letters) // 3. Перемешивание букв
    {
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            int randomIndex = Random.Range(0, letters.Length);
            letters[i] = letters[randomIndex];
            letters[randomIndex] = c;
        }
        return letters;
    }

    void Create(string word) //4. Создание картинок с буквами
    {
        char[] characters = word.ToCharArray();
        char[] MixedLetters = LetterShuffle(characters);

        for (int i = 0; i < MixedLetters.Length; i++)
        {
            string number = MixedLetters[i].ToString();
            string nameLogo = MixedLetters[i].ToString();


            letter = Instantiate(letter, Hand.transform);

            letter.SetActive(true);
            letter.name = number;
            letter.GetComponent<Image>().sprite = Resources.Load<Sprite>(nameLogo);
        }
        isDone = true;
    }

    public void ChekLetters() // 6. Проверка условия
    {
        if (letter.transform.parent.name == "Field")
        {
            if (letter.transform.parent.gameObject.name == "TempCardGO")
            {
                count = letter.transform.parent.childCount - 1;
            }
            else
            {
                count = letter.transform.parent.childCount;
            }

            if (count == word.Length && letter.transform.parent.GetChild(0) != null)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    chek += letter.transform.parent.GetChild(i).name;
                }

                if (chek == word)
                {

                    chek = "";
                    arrayIndex += 1;
                    score += 100;

                    for (int j = 0; j < count; j++)
                    {
                        letter.transform.parent.GetChild(j).gameObject.SetActive(false);
                        Destroy(letter.transform.parent.GetChild(j).gameObject, 1);

                    }

                    isDone = false;
                }
                else
                {
                    chek = "";
                }
            }

            if (arrayIndex == 30)
            {
                SceneManager.LoadScene("AfterGameScene");
            }
            else
            {
                word = WordsMixArray[arrayIndex];
            }
        }
    }
}

    

