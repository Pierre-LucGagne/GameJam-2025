using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchatArme : MonoBehaviour
{
   
     [SerializeField] private GameObject _astrofuseur;
     [SerializeField] private GameObject _sextant;
    
    
    [SerializeField] private GameObject _astrofuseurActive;
    [SerializeField] private GameObject _sextantActive;
    

    [SerializeField] private ListeArmes _listeArmes;


   
    private bool _isAstrofuseurTaken = false;
    private bool _isSextantTaken = false;


    [SerializeField] private GameObject _crochetCanvas2; //pour dire qu'il est acheter voir avec mon chou

   
    [SerializeField] private Button _astrofuseurButton;
    [SerializeField] private Button _sextantButton;
    

  private void Start()
    {
        // Vérifier si les boutons sont assignés avant d'ajouter les listeners
        if (_astrofuseurButton != null)
        {
            _astrofuseurButton.onClick.AddListener(BuyAstrofuseur);
        }
        else
        {
            Debug.LogError("Astrofuseur button is not assigned in the inspector!");
        }

        if (_sextantButton != null)
        {
            _sextantButton.onClick.AddListener(BuySextant);
        }
        else
        {
            Debug.LogError("Sextant button is not assigned in the inspector!");
        }
    }
   public bool IsAstrofuseurTaken(){

    return _isAstrofuseurTaken;
    
   }

   
   public bool IsSextantTaken(){

    return _isSextantTaken;
    
   }
     private void BuyAstrofuseur()
    {
        if (!_isAstrofuseurTaken)
        {
            _isAstrofuseurTaken = true;
            if (_listeArmes != null)
            {
                _listeArmes.ArmeAcheter("Astrofuseur");
                _crochetCanvas2.SetActive(true); // Afficher l'UI associée à l'achat
            }
            _astrofuseurActive.SetActive(true);
            Destroy(_astrofuseur); // Détruire l'arme dans le jeu
        }
    }

    // Fonction pour acheter le Sextant
    private void BuySextant()
    {
        if (!_isSextantTaken)
        {
            _isSextantTaken = true;
            if (_listeArmes != null)
            {
                _listeArmes.ArmeAcheter("Sextant");
                _crochetCanvas2.SetActive(true); // Afficher l'UI associée à l'achat
            }
            _sextantActive.SetActive(true);
            Destroy(_sextant); // Détruire l'arme dans le jeu
        }
    }
}
