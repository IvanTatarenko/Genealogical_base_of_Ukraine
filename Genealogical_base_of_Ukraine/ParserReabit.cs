using AngleSharp;
using AngleSharp.Dom;
using MySql.Data.MySqlClient;

namespace Genealogical_base_of_Ukraine
{
    internal class ParserReabit
    {
        public async Task reabit()
        {
            string url = "http://www.reabit.org.ua/nbr/?ID=";
            int id = 31935;
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);
            Program.f1.console_box.Text += Environment.NewLine + "Починаємо парсінг";
            while (id < 371662)
            {
                Program.f1.console_box.Text += Environment.NewLine + "Парсимо документ з ID - " + id.ToString();
                string doc_type;
                string doc_url;

                string firstname;
                string lastname;
                string surname;
                string date_of_birth;
                //foto
                string place_of_birth;
                string nationality;
                string social_origin;
                string political_activity;
                string education;
                string activity;
                string last_place_of_residence;
                string last_place_of_work;
                string family_composition;
                string date_of_arrest;
                string convict;
                string convict_family;
                string after_conviction;
                string rehabilitation;
                string about_death;
                string doc_namber;
                string notes;
                string pars_url = url + id.ToString();
                //connection to the database
                DB db = new DB();
                MySqlDataReader dr;
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM `docs` WHERE doc_url = @doc_url", db.getConnection());
                command2.Parameters.Add("@doc_url", MySqlDbType.VarChar).Value = pars_url;
                db.openConnection();
                dr = command2.ExecuteReader();
                if (dr.HasRows)
                {
                    Program.f1.console_box.Text += Environment.NewLine + "Такий документ вже є - ";
                    id++;
                    continue;
                }



                db.closeConnection();
                using var doc = await context.OpenAsync(pars_url);
                var table_doc = doc.QuerySelector("div.nbr_card");
                if(table_doc != null)
                {
                    var doc_table_div = table_doc.QuerySelectorAll("div.fd");
                    doc_url = pars_url;
                    doc_type = "reabit";
                    if (doc_table_div[1] != null) firstname = doc_table_div[1].Text().Trim();
                    else firstname = "нема даних";

                    if (doc_table_div[0] != null) lastname = doc_table_div[0].Text().Trim();
                    else lastname = "нема даних";

                    if (doc_table_div[2] != null) surname = doc_table_div[2].Text().Trim();
                    else surname = "нема даних";

                    if (doc_table_div[3] != null) date_of_birth = doc_table_div[3].Text().Trim();
                    else date_of_birth = "нема даних";

                    if (doc_table_div[5] != null) place_of_birth = doc_table_div[5].Text().Trim();
                    else place_of_birth = "нема даних";

                    if (doc_table_div[6] != null) nationality = doc_table_div[6].Text().Trim();
                    else nationality = "нема даних";

                    if (doc_table_div[7] != null) social_origin = doc_table_div[7].Text().Trim();
                    else social_origin = "нема даних";

                    if (doc_table_div[8] != null) political_activity = doc_table_div[8].Text().Trim();
                    else political_activity = "нема даних";

                    if (doc_table_div[9] != null) education = doc_table_div[9].Text().Trim();
                    else education = "нема даних";

                    if (doc_table_div[10] != null) activity = doc_table_div[10].Text().Trim();
                    else activity = "нема даних";

                    if (doc_table_div[11] != null) last_place_of_residence = doc_table_div[11].Text().Trim();
                    else last_place_of_residence = "нема даних";

                    if (doc_table_div[12] != null) last_place_of_work = doc_table_div[12].Text().Trim();
                    else last_place_of_work = "нема даних";

                    if (doc_table_div[13] != null) family_composition = doc_table_div[13].Text().Trim();
                    else family_composition = "нема даних";

                    if (doc_table_div[14] != null) date_of_arrest = doc_table_div[14].Text().Trim();
                    else date_of_arrest = "нема даних";

                    if (doc_table_div[15] != null) convict = doc_table_div[15].Text().Trim();
                    else convict = "нема даних";

                    if (doc_table_div[16] != null) convict_family = doc_table_div[16].Text().Trim();
                    else convict_family = "нема даних";

                    if (doc_table_div[17] != null) after_conviction = doc_table_div[17].Text().Trim();
                    else after_conviction = "нема даних";

                    if (doc_table_div[18] != null) rehabilitation = doc_table_div[18].Text().Trim();
                    else rehabilitation = "нема даних";

                    if (doc_table_div[19] != null) about_death = doc_table_div[19].Text().Trim();
                    else about_death = "нема даних";
                    
                    if (doc_table_div[20] != null) doc_namber = doc_table_div[20].Text().Trim();
                    else doc_namber = "нема даних";
                    
                    if (doc_table_div[21] != null) notes = doc_table_div[21].Text().Trim();
                    else notes = "нема даних";










                    MySqlCommand command = new MySqlCommand("INSERT INTO `docs` (`doc_type`, `doc_url`, `firstname`, `lastname`, `surname`, `date_of_birth`, `place_of_birth`, `nationality`, `social_origin`, `political_activity`, `education`, `activity`, `last_place_of_residence`, `last_place_of_work`, `family_composition`, `date_of_arrest`, `convict`, `convict_family`, `after_conviction`, `rehabilitation`, `about_death`, `doc_namber`, `notes`) VALUES (@doc_type, @doc_url, @firstname, @lastname, @surname, @date_of_birth, @place_of_birth, @nationality, @social_origin, @political_activity, @education, @activity, @last_place_of_residence, @last_place_of_work, @family_composition, @date_of_arrest, @convict, @convict_family, @after_conviction, @rehabilitation, @about_death, @doc_namber, @notes)", db.getConnection());
                    //mask requests
                    command.Parameters.Add("@doc_type", MySqlDbType.VarChar).Value = doc_type;
                    command.Parameters.Add("@doc_url", MySqlDbType.VarChar).Value = doc_url;
                    command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                    command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                    command.Parameters.Add("@date_of_birth", MySqlDbType.VarChar).Value = date_of_birth;
                    command.Parameters.Add("@place_of_birth", MySqlDbType.VarChar).Value = place_of_birth;
                    command.Parameters.Add("@nationality", MySqlDbType.VarChar).Value = nationality;
                    command.Parameters.Add("@social_origin", MySqlDbType.VarChar).Value = social_origin;
                    command.Parameters.Add("@political_activity", MySqlDbType.VarChar).Value = political_activity;
                    command.Parameters.Add("@education", MySqlDbType.VarChar).Value = education;
                    command.Parameters.Add("@activity", MySqlDbType.VarChar).Value = activity;
                    command.Parameters.Add("@last_place_of_residence", MySqlDbType.VarChar).Value = last_place_of_residence;
                    command.Parameters.Add("@last_place_of_work", MySqlDbType.VarChar).Value = last_place_of_work;
                    command.Parameters.Add("@family_composition", MySqlDbType.VarChar).Value = family_composition;
                    command.Parameters.Add("@date_of_arrest", MySqlDbType.VarChar).Value = date_of_arrest;
                    command.Parameters.Add("@convict", MySqlDbType.VarChar).Value = convict;
                    command.Parameters.Add("@convict_family", MySqlDbType.VarChar).Value = convict_family;
                    command.Parameters.Add("@after_conviction", MySqlDbType.VarChar).Value = after_conviction;
                    command.Parameters.Add("@rehabilitation", MySqlDbType.VarChar).Value = rehabilitation;
                    command.Parameters.Add("@about_death", MySqlDbType.VarChar).Value = about_death;
                    command.Parameters.Add("@doc_namber", MySqlDbType.VarChar).Value = doc_namber;
                    command.Parameters.Add("@notes", MySqlDbType.VarChar).Value = notes;
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    Program.f1.console_box.Text += Environment.NewLine + "Додаємо документ з ID - " + id.ToString();
                    double pr = Convert.ToDouble(id) / 371662.00 * 100.00;
                    Program.f1.label1.Text = pr.ToString() + " %";

                }
                
                id ++;
            }

            //.Text().Trim();
            //var table_doc = doc.QuerySelectorAll("li.interlanguage-link.interwiki-uk.mw-list-item");
            //var table3_doc = table2_doc[0].QuerySelectorAll("a");
            //wiki_url_ua = table3_doc[0].GetAttribute("href");
        }
    }
}


