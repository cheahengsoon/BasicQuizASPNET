using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Data.SqlClient;


namespace BasicQuizASPNET_v1_
{
    public partial class questionPage : System.Web.UI.Page
    {
        //Lists to temporarily store the database information.
        Question QuestionRow = new Question();
        List<Question> QuestionRowList = new List<Question>();
        UserScore UserScoreRow = new UserScore();
        List<UserScore> UserScoreRowList = new List<UserScore>();
        int intUserID;
        int intUserAnswerID;
        int intQuestionID;
        string strUserAnwserDescription;
        int intCorrectAnswerID;
        string strCorrectAnswerDescription;
        int intUserQuestionScore;
        int intRowListCount;
        int intTestQuestionNumber = 1;
        int intTotalScore = 0;
        string strQuestionDescription;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the UserID form the defaultPage.aspx
            //intUserID = (int)Session["m_intUserID"];
            if (!IsPostBack)
            {
                ClearUserScoreTable();
            }

            if (Session["m_intTestQuestionNumber"] != null)
            {
                if ((int)Session["m_intTestQuestionNumber"] > 1)
                {
                    intTestQuestionNumber = (int)Session["m_intTestQuestionNumber"];
                }
            }

            ReadQuestionTable();

            foreach (Question objQuestion in QuestionRowList)
            {
                if (objQuestion.intQuestionID == intTestQuestionNumber)
                {
                    lblQuestion.Text = objQuestion.strQuestionDescription;
                    intQuestionID = objQuestion.intQuestionID;
                    strQuestionDescription = objQuestion.strQuestionDescription;
                    radioButton1.Text = objQuestion.strAnswer1Description;
                    radioButton2.Text = objQuestion.strAnswer2Description;
                    radioButton3.Text = objQuestion.strAnswer3Description;
                    intCorrectAnswerID = objQuestion.intCorrectAnswerID;
                    strCorrectAnswerDescription = objQuestion.strCorrectAnswerDescription;
                    Session["m_strAnswer1Description"] = objQuestion.strAnswer1Description;
                    Session["m_strAnswer2Description"] = objQuestion.strAnswer2Description;
                    Session["m_strAnswer3Description"] = objQuestion.strAnswer3Description;
                    Session["m_intCorrectAnswerID"] = intCorrectAnswerID;
                    Session["m_strQuestionDescription"] = strQuestionDescription;
                    Session["m_strCorrectAnswerDescription"] = strCorrectAnswerDescription;
                }
            }// end foreach

        }// end Page_Load

        protected void btnNext_Click(object sender, EventArgs e)
        {
            
            
            if (radioButton1.Checked)
            {
                intUserAnswerID = 1;
            }
            if (radioButton2.Checked)
            {
                intUserAnswerID = 2;
            }
            if (radioButton3.Checked)
            {
                intUserAnswerID = 3;
            }

            foreach (Question objQuestion in QuestionRowList)
            {
                if (objQuestion.intQuestionID == intTestQuestionNumber)
                {
                    if (objQuestion.intCorrectAnswerID == intUserAnswerID)
                    {
                        lblResult.Text = "Your answer is correct!";
                        if (Session["m_intTotalScore"] != null)
                        {
                            intTotalScore = (int)Session["m_intTotalScore"];
                        }
                        intTotalScore++;
                        Session["m_intTotalScore"] = intTotalScore;

                        intUserQuestionScore = 1;
                        lblResult.Visible = true;
                    }
                    else
                    {
                        lblResult.Text = "Your answer is NOT correct.";
                        intUserQuestionScore = 0;
                        lblResult.Visible = true;
                    }


                    switch (intUserAnswerID)
                    {
                        case 1:
                            strUserAnwserDescription = (string)Session["m_strAnswer1Description"];
                            break;
                        case 2:
                            strUserAnwserDescription = (string)Session["m_strAnswer2Description"];
                            break;
                        case 3:
                            strUserAnwserDescription = (string)Session["m_strAnswer3Description"];
                            break;
                    }

                    Session["m_strUserAnwserDescription"] = strUserAnwserDescription;

                }// end if 

            }// end foreach

            /////////////////////////////////Begin Insert//////////////////////////////////////////////////////
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=quiz1;Integrated Security=True";

            try
            {
                intUserID = (int)Session["m_intUserID"];
                strQuestionDescription = (string)Session["m_strQuestionDescription"];
                strCorrectAnswerDescription = (string)Session["m_strCorrectAnswerDescription"];

                conn.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO UserScore (UserID, QuestionID, QuestionDescription, UserAnswerID, UserAnswerDescription, CorrectAnswerID, " +
                        "CorrectAnswerDescription, UserQuestionScore)" + " VALUES (" + intUserID + ", '" + intQuestionID
                        + "', " + "'" + strQuestionDescription + "', " + intUserAnswerID + ", '"
                        + strUserAnwserDescription + "', " + intCorrectAnswerID + ",'" + strCorrectAnswerDescription + "', "
                        + intUserQuestionScore + ")", conn);

                command.ExecuteNonQuery();
            }// end try

            catch (Exception ex)
            {
                lblMessage.Text = "Failed to insert to UserScore";
            }
            finally
            {
                conn.Close();
            }
            //////////////////////////////////End Insert////////////////////////////////////////////////

            dataGridView1.DataBind();
            intTestQuestionNumber++;
            Session["m_intTestQuestionNumber"] = intTestQuestionNumber;

            double dblAverageScore;

            if (intTestQuestionNumber > QuestionRowList.Count)
            {
                intTotalScore = (int)Session["m_intTotalScore"];
                lblScore.Text = "Your total score is: " + intTotalScore;
                dblAverageScore = (double)intTotalScore / QuestionRowList.Count;
                dblAverageScore = dblAverageScore * 100;
                lblAverageScore.Text = "Your average score is: " + (int)dblAverageScore + "%";
                lblAverageScore.Visible = true;
                lblScore.Visible = true;
                btnNext.Visible = false;
                btnExit.Visible = true;
                lblQuestion.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;

                return;
            }

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            foreach (Question objQuestion in QuestionRowList)
            {
                if (objQuestion.intQuestionID == intTestQuestionNumber)
                {
                    lblQuestion.Text = objQuestion.strQuestionDescription;
                    strQuestionDescription = objQuestion.strQuestionDescription;
                    radioButton1.Text = objQuestion.strAnswer1Description;
                    radioButton2.Text = objQuestion.strAnswer2Description;
                    radioButton3.Text = objQuestion.strAnswer3Description;
                    intCorrectAnswerID = objQuestion.intCorrectAnswerID;
                    strCorrectAnswerDescription = objQuestion.strCorrectAnswerDescription;
                    Session["m_strAnswer1Description"] = objQuestion.strAnswer1Description;
                    Session["m_strAnswer2Description"] = objQuestion.strAnswer2Description;
                    Session["m_strAnswer3Description"] = objQuestion.strAnswer3Description;
                    Session["m_intCorrectAnswerID"] = intCorrectAnswerID;
                    Session["m_strQuestionDescription"] = strQuestionDescription;
                    Session["m_strCorrectAnswerDescription"] = strCorrectAnswerDescription;
                }
            }// end foreach


        } // end btnNext_Click

        private void ReadUserScoreTable()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=quiz1;Integrated Security=True";

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM UserScore;",
                    conn);

                SqlDataReader reader = command.ExecuteReader();

                intRowListCount = 0;
                UserScoreRowList.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserScore ur = new UserScore();
                        ur.intRowID = (int)reader[0];
                        ur.intUserID = (int)reader[1];
                        ur.intQuestionID = (int)reader[2];
                        ur.strQuestionDescription = (string)reader[3];
                        ur.intUserAnswerID = (int)reader[4];
                        ur.strUserAnswerDescription = (string)reader[5];
                        ur.intCorrectAnswerID = (int)reader[6];
                        ur.strCorrectAnswerDescription = (string)reader[7];
                        ur.intUserQuestionScore = (int)reader[8];
                        UserScoreRowList.Add(ur);
                        intRowListCount++;
                    }
                }// end if (reader.HasRows)
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();

            }// end try

            catch (Exception ex)
            {
                lblMessage.Text = "Failed to read user score";
            }
            finally
            {
                conn.Close();
            }
        } // end ReadUserScoreTable

        private void ReadQuestionTable()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=quiz1;Integrated Security=True";

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM Question;",
                    conn);

                SqlDataReader reader = command.ExecuteReader();

                intRowListCount = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Question qr = new Question();
                        qr.intQuestionID = (int)reader[0];
                        qr.strQuestionDescription = (string)reader[1];
                        qr.intAnswer1ID = (int)reader[2];
                        qr.strAnswer1Description = (string)reader[3];
                        qr.intAnswer2ID = (int)reader[4];
                        qr.strAnswer2Description = (string)reader[5];
                        qr.intAnswer3ID = (int)reader[6];
                        qr.strAnswer3Description = (string)reader[7];
                        qr.intCorrectAnswerID = (int)reader[8];
                        qr.strCorrectAnswerDescription = (string)reader[9];
                        QuestionRowList.Add(qr);
                        intRowListCount++;
                    }
                }// end if (reader.HasRows)
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();

            }// end try

            catch (Exception ex)
            {
                lblMessage.Text = "Failed to connect to Question table";
            }
            finally
            {
                conn.Close();
            }
        } // end ReadQuestionTable

        private void ClearUserScoreTable()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=quiz1;Asynchronous Processing=True;Integrated Security=True";

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM UserScore;",
                    conn);

                command.ExecuteNonQuery();

            }// end try

            catch (Exception ex)
            {
                lblMessage.Text = "Failed to connect to UserScore table";
            }
            finally
            {
                conn.Close();
            }
        } // end ClearUserScoreTable

        protected void btnExit_Click(object sender, EventArgs e)
        {
            lblExit.Visible = true;
            lblAverageScore.Visible = false;
            lblMessage.Visible = false;
            lblQuestion.Visible = false;
            lblResult.Visible = false;
            lblScore.Visible = false;
            dataGridView1.Visible = false;
            btnExit.Visible = false;
        }// end btnExit_Click

    }// end partial class questionPage : System.Web.UI.Page
}// end namespace BasicQuizASPNET_v1_