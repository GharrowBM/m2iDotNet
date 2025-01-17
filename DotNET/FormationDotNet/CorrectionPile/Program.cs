﻿using CorrectionPile.Classes;
using System;
using System.Collections.Generic;

namespace CorrectionPile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pile<string> pileString = new Pile<string>(4);
            //pileString.Empiler("test1");
            //pileString.Empiler("test2");
            //pileString.Empiler("test5");
            //pileString.Empiler("test4");
            //pileString.Depiler();
            //pileString.Empiler("test5");

            //Pile<int> pileInt = new Pile<int>(5);

            Pile<Voiture> voitures = new Pile<Voiture>(3);
            voitures.PilePleine += ActionPilePleine;
            voitures.Empiler(new Voiture("ford"));
            voitures.Empiler(new Voiture("kia"));
            voitures.Empiler(new Voiture("opel"));
            voitures.Empiler(new Voiture("opel"));
            voitures.Empiler(new Voiture("opel"));

            //Voiture voiture = voitures.Search(v => v.Model == "kia");
            //Voiture voiture = voitures.Search(v => v.Model.Contains("o"));
            List<Voiture> v = voitures.SearchAll(v => v.Model.Contains("o"));
        }


        static void ActionPilePleine()
        {
            Console.WriteLine("La pile est pleine");
        }
    }
}
