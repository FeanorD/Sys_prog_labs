﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GetFromSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True";
            string sql = "SELECT * FROM MyMusicalGroups_";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
