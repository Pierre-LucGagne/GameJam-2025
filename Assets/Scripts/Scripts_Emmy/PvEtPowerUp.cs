using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PvEtPowerUp : MonoBehaviour
{
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private InfosJeu _infosDuJeu;

    // Images des PV
    public Image[] sectionPv;

    private int _nbPVPresentement;

    void Start()
    {
        _nbPVPresentement = _infosJoueurs._nbPvDepart;
        MettreAJourBarrePV();
    }

    // Méthode appelée lorsqu'on perd un PV
    private void PerdrePV()
    {
        _nbPVPresentement--;
        MettreAJourBarrePV();
        VerifierFinDePartie();
    }

    // Méthode appelée lorsqu'on gagne un PV
    public void BonusPV(int PvCup)
    {
        
        // Ajout du bonus PV
        _infosJoueurs._bonusPv += PvCup;
        _nbPVPresentement = Mathf.Min(_infosJoueurs._nbPvDepart + _infosJoueurs._bonusPv, _infosJoueurs._nbPvDepart);

        MettreAJourBarrePV();
    }

    // Met à jour visuellement la barre de PV
    private void MettreAJourBarrePV()
    {
        for (int i = 0; i < sectionPv.Length; i++)
        {
            if (i < _nbPVPresentement)
            {
          
                sectionPv[i].gameObject.SetActive(true);
            }
            else
            {
                sectionPv[i].gameObject.SetActive(false);
            }
        }
    }

    // Vérifie si la partie est terminée
    private void VerifierFinDePartie()
    {
        if (_nbPVPresentement <= 0)
        {
            _infosDuJeu._victoirePartie = false;
            _infosDuJeu._defaitePartie = true;

            // Ajoute ici la logique pour changer de scène, afficher un menu, etc.
        }
    }
}
