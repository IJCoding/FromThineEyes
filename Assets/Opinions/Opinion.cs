using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "newOpinion", menuName = "Opinions")]
public class Opinion : ScriptableObject
{
    private Dictionary<Interactable, Dictionary<string, Trait>> _Opinions = new Dictionary<Interactable, Dictionary<string, Trait>>();
    
    public Dictionary<Interactable, Dictionary<string, Trait>> GetDictOpinion() { return _Opinions; }

    public Dictionary<string, Trait> GetOpinion(Interactable subject) { return _Opinions[subject]; }

    //Check if the entity has any views on the subject
    public bool HasOpinion(Interactable subject) {  return _Opinions.ContainsKey(subject); }

    //Check if the entity has a specfic view on the subject (if no opinion is held defaults to false)
    public bool HasView(Interactable subject, Trait opinion) 
    {
        return HasOpinion(subject) && _Opinions[subject].ContainsKey(opinion.GetName());
    }

    public void AddOpinion(Interactable subject, Trait opinion)
    {
        //If doesnt have an opinion make a blank opinion on the subject
        if (!HasOpinion(subject)) { _Opinions.Add(subject, new Dictionary<string, Trait>()); }

        //As will now have some opinion, check it doesnt already have the same opinon
        if (!HasView(subject, opinion)) { _Opinions[subject].Add(opinion.GetName(), opinion); }
    }

    public void RemoveOpinion(Interactable subject, Trait opinion)
    {
        RemoveOpinion(subject, opinion.GetName());
    }

    public void RemoveOpinion(Interactable subject, string opinion)
    {
        if (HasOpinion(subject))
        {
            _Opinions[subject].Remove(opinion);
        }
    }

    public void ClearOpinion(Interactable subject)
    {
        if(HasOpinion(subject))
        {
            List<string> allKeys = new List<string>(GetOpinion(subject).Keys);

            foreach (string key in allKeys)
            {
                RemoveOpinion(subject, key);
            }
        }
    }

    public void ClearAllOpinions()
    {
        List<Interactable> allKeys = new List<Interactable>(GetDictOpinion().Keys);

        foreach (Interactable key in allKeys)
        {
            ClearOpinion(key);
        }
    }

    private void OnEnable()
    {
        Interactable testI0 = Interactable.CreateInstance<Interactable>();
        Interactable testI1 = Interactable.CreateInstance<Interactable>();

        testI0.name = "testInteractable0";
        testI1.name = "testInteractable1";

        AddOpinion(testI0, Trait.CreateInstance<Trait>());
        AddOpinion(testI1, Trait.CreateInstance<Trait>());               

    }

}