﻿using CaisseEnregistreuse.Classes;
using CaisseEnregistreuse.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.DAO
{
    internal class VenteDAO : BaseDAO
    {
        public bool Save(Vente vente,  IPaiement paiement, SqlConnection connection, SqlTransaction transaction)
        {
            //connection = Connection;
            request = "INSERT INTO vente (total, etat, type_paiement) " +
                "OUTPUT INSERTED.ID values (@total, @etat, @type_paiement)";
            command = new SqlCommand(request, connection);
            command.Transaction = transaction;
            command.Parameters.Add(new SqlParameter("@total", vente.Total));
            command.Parameters.Add(new SqlParameter("@etat", vente.Etat));
            command.Parameters.Add(new SqlParameter("@type_paiement", paiement.ToString()));
            //connection.Open();
            vente.Id = (int)command.ExecuteScalar();
            command.Dispose();
            //connection.Close();
            return vente.Id > 0;
        }

        public bool SaveVenteProduit(Vente vente, SqlConnection connection, SqlTransaction transaction)
        {
            bool result = true;
            //connection = Connection;
            //connection.Open();
            foreach(Produit p in vente.Produits)
            {
                request = "INSERT INTO vente_produit (produit_id, vente_id) " +
                "values (@produit_id, @vente_id)";
                command = new SqlCommand(request, connection);
                command.Transaction= transaction;
                command.Parameters.Add(new SqlParameter("@produit_id", p.Id));
                command.Parameters.Add(new SqlParameter("@vente_id", vente.Id));
                int nbRow = command.ExecuteNonQuery();
                result = nbRow == 1;
                command.Dispose();
                if (!result)
                {
                    break;
                }
            }
            //connection.Close();
            return result;
        }
    }
}