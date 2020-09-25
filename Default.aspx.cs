﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.UI.WebControls;

namespace MyIPSWMinimal
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                btnRetrieve.Visible = false;
                lblStep2.Visible = false;
                lblStep3.Visible = false;
                ddliPhone.Visible = false;
                ddliPad.Visible = false;
                ddliPod.Visible = false;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;


                WebClient webClient = new WebClient();
                string myJSON = webClient.DownloadString("https://api.ipsw.me/v4/devices");

                dynamic jsonObj = JsonConvert.DeserializeObject(myJSON);
                for (int i = 0; i < jsonObj.Count; i++)
                {

                    string name = jsonObj[i]["name"].ToString();
                    string identifier = jsonObj[i]["identifier"].ToString();
                    if (identifier.Contains("iPhone"))
                    {
                        ddliPhone.Items.Add(new ListItem(name, identifier));
                    }
                    else if (identifier.Contains("iPad"))
                    {
                        ddliPad.Items.Add(new ListItem(name, identifier));
                    }
                    else if (identifier.Contains("Watch"))
                    {
                        ddlWatch.Items.Add(new ListItem(name, identifier));
                    }
                    else if (identifier.Contains("AudioAccessory")) //HomePod
                    {
                        ddlAudioAccessory.Items.Add(new ListItem(name, identifier));
                    }
                    else if (identifier.Contains("iPod"))
                    {
                        ddliPod.Items.Add(new ListItem(name, identifier));
                    }
                    else if (identifier.Contains("AppleTV"))
                    {
                        ddlAppleTV.Items.Add(new ListItem(name, identifier));
                    }
                }

                string[] iOSVersion = new string[] { "1.0", "1.0.1", "1.0.2", "1.1", "1.1.1", "1.1.2", "1.1.3", "1.1.4", "1.1.5",
                                                        "2.0", "2.0.1", "2.0.2", "2.1", "2.1.1", "2.2", "2.2.1",
                                                        "3.0", "3.0.1", "3.1", "3.1.1", "3.1.2", "3.1.3", "3.2", "3.2.1", "3.2.2",
                                                        "4.0", "4.0.1", "4.0.2", "4.1", "4.2.1", "4.2.6", "4.2.7", "4.2.8", "4.2.9", "4.2.10", "4.3", "4.3.1", "4.3.2", "4.3.3", "4.3.4", "4.3.5",
                                                        "5.0", "5.0.1", "5.1", "5.1.1",
                                                        "6.0", "6.0.1", "6.0.2", "6.1", "6.1.1", "6.1.2", "6.1.3", "6.1.4", "6.1.5", "6.1.6",
                                                        "7.0", "7.0.1", "7.0.2", "7.0.3", "7.0.4", "7.0.5", "7.0.6", "7.1", "7.1.1", "7.1.2",
                                                        "8.0", "8.0.1", "8.0.2", "8.1", "8.1.1", "8.1.2", "8.1.3", "8.2", "8.3", "8.4", "8.4.1",
                                                        "9.0", "9.0.1", "9.0.2", "9.1", "9.2", "9.2.1", "9.3", "9.3.1", "9.3.2", "9.3.3", "9.3.4", "9.3.5", "9.3.6",
                                                        "10.0", "10.0.1", "10.0.2", "10.0.3", "10.1", "10.1.1", "10.2", "10.2.1", "10.3", "10.3.1", "10.3.2", "10.3.3", "10.3.4",
                                                        "11.0", "11.0.1", "11.0.2", "11.0.3", "11.1", "11.1.1", "11.1.2", "11.2", "11.2.1", "11.2.2", "11.2.5", "11.2.6", "11.3", "11.3.1", "11.4", "11.4.1",
                                                        "12.0", "12.0.1", "12.1", "12.1.1", "12.1.2", "12.1.3", "12.1.4", "12.2", "12.3", "12.3.1", "12.3.2", "12.4", "12.4.1", "12.4.2", "12.4.3", "12.4.4", "12.4.5",
                                                        "13.0", "13.1", "13.1.1", "13.1.2", "13.1.3", "13.2", "13.2.2", "13.2.3", "13.3", "13.3.1", "13.4", "13.4.1", "13.4.6", "13.5", "13.5.1", "13.6", "13.6.1","13.7",
                                                        "14.0","14.0.1"
                    };

                string[] OTAVersion = new string[] { "2.0", "2.0.1", "2.1", "2.2", "2.2.1",
                                                        "3.0",  "3.1", "3.1.1", "3.1.3", "3.2", "3.2.2",
                                                        "4.0", "4.0.1",  "4.1", "4.2", "4.2.2", "4.2.3", "4.3", "4.3.1", "4.3.2",
                                                        "5.0", "5.0.1", "5.1", "5.1.1", "5.1.2", "5.1.3", "5.2", "5.2.1", "5.3", "5.3.1", "5.3.2", "5.3.3", "5.3.4", "5.3.5",
                                                        "6.0", "6.0.1", "6.1", "6.1.1",  "6.1.3", "6.1.4", "6.1.5", "6.1.6",
                                                        "7.0", "7.0.1", "7.0.2", "7.0.3", "7.0.4", "7.0.5", "7.0.6", "7.1", "7.1.1", "7.1.2",
                                                        "8.0", "8.0.1", "8.0.2", "8.1", "8.1.1", "8.1.2", "8.1.3", "8.2", "8.2.1", "8.3", "8.4", "8.4.1", "8.4.2", "8.4.3",
                                                        "9.0", "9.0.1", "9.0.2", "9.1", "9.2", "9.2.1", "9.2.2", "9.3", "9.3.1", "9.3.2", "9.3.3", "9.3.4", "9.3.5", "9.3.6",
                                                        "10.0", "10.0.1", "10.0.2", "10.0.3", "10.1", "10.1.1", "10.2", "10.2.1", "10.2.2", "10.3", "10.3.1", "10.3.2", "10.3.3", "10.3.4", "9.9.10.0.1", "9.9.10.0.3", "9.9.10.1", "9.9.10.1.1", "9.9.10.2", "9.9.10.2.1", "9.9.10.3", "9.9.10.3.1", "9.9.10.3.2", "9.9.10.3.3",
                                                        "11.0", "11.0.1", "11.0.2", "11.0.3", "11.1", "11.1.1", "11.1.2", "11.2", "11.2.1", "11.2.2", "11.2.5", "11.2.6", "11.3", "11.3.1", "11.4", "11.4.1", "9.9.11.0", "9.9.11.0.1", "9.9.11.0.3", "9.9.11.1", "9.9.11.1.1", "9.9.11.2", "9.9.11.2.1", "9.9.11.2.2", "9.9.11.2.5", "9.9.11.2.6", "9.9.11.3", "9.9.11.3.1", "9.9.11.4", "9.9.11.4.1",
                                                        "12.0", "12.0.1", "12.1", "12.1.1", "12.1.2", "12.1.3", "12.2", "12.2.1", "12.3", "12.3.1", "12.4", "12.4.1","9.9.12.0", "9.9.12.0.1", "9.9.12.1", "9.9.12.1.1", "9.9.12.1.2", "9.9.12.1.3","9.9.12.1.4", "9.9.12.2", "9.9.12.3", "9.9.12.3.1", "9.9.12.4", "9.9.12.4.1",
                                                        "13.0", "13.1", "13.2", "13.3", "13.3.1", "13.4", "13.4.1", "13.4.5", "13.4.6", "13.4.8", "13.5", "13.6", "9.9.13.0", "9.9.13.1", "9.9.13.1.1", "9.9.13.1.2", "9.9.13.1.3", "9.9.13.2", "9.9.13.2.2", "9.9.13.2.3", "9.9.13.3", "9.9.13.3.1", "9.9.13.4", "9.9.13.4.1","9.9.13.4.5", "9.9.13.4.6", "9.9.13.5", "9.9.13.5.1", "9.9.13.5.5", "9.9.13.6", "9.9.13.6.1", "9.9.13.7", 
                                                        "9.9.14.0"

                    };

                for (int x = 0; x < iOSVersion.Length; x++)
                {
                    ddlVersion.Items.Add(new ListItem(iOSVersion[x], iOSVersion[x]));
                }

                for (int y = 0; y < OTAVersion.Length; y++)
                {
                    ddlVersionOTA.Items.Add(new ListItem(OTAVersion[y], OTAVersion[y]));
                }


            }

        }

        protected void ddliPhone_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelection.Text = ddliPhone.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddliPhone.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }

            ddliPad.SelectedIndex = 0;
            ddliPod.SelectedIndex = 0;
            ddlWatch.SelectedIndex = 0;
            ddlAppleTV.SelectedIndex = 0;
            ddlAudioAccessory.SelectedIndex = 0;
        }

        protected void rblOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("Version"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = false;
                ddliPad.Visible = false;
                ddliPod.Visible = false;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = true;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("Version (OTA)"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = false;
                ddliPad.Visible = false;
                ddliPod.Visible = false;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = true;
            }

        }

        protected void ddliPad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddliPhone.SelectedIndex = 0;
            ddliPod.SelectedIndex = 0;
            ddlWatch.SelectedIndex = 0;
            ddlAppleTV.SelectedIndex = 0;
            ddlAudioAccessory.SelectedIndex = 0;

            lblSelection.Text = ddliPad.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddliPad.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }


        }

        protected void ddliPod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddliPhone.SelectedIndex = 0;
            ddliPad.SelectedIndex = 0;
            ddlWatch.SelectedIndex = 0;
            ddlAppleTV.SelectedIndex = 0;
            ddlAudioAccessory.SelectedIndex = 0;

            lblSelection.Text = ddliPod.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddliPod.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }



        }

        protected void ddlWatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddliPhone.SelectedIndex = 0;
            ddliPad.SelectedIndex = 0;
            ddliPod.SelectedIndex = 0;
            ddlAppleTV.SelectedIndex = 0;
            ddlAudioAccessory.SelectedIndex = 0;

            lblSelection.Text = ddlWatch.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddlWatch.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }

        }

        protected void ddlAudioAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddliPhone.SelectedIndex = 0;
            ddliPad.SelectedIndex = 0;
            ddliPod.SelectedIndex = 0;
            ddlWatch.SelectedIndex = 0;
            ddlAppleTV.SelectedIndex = 0;

            lblSelection.Text = ddlAudioAccessory.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddlAudioAccessory.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }


        }

        protected void ddlAppleTV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddliPhone.SelectedIndex = 0;
            ddliPad.SelectedIndex = 0;
            ddliPod.SelectedIndex = 0;
            ddlWatch.SelectedIndex = 0;
            ddlAudioAccessory.SelectedIndex = 0;

            lblSelection.Text = ddlAppleTV.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected <b>" + rblOptions.SelectedItem.ToString() + " " + ddlAppleTV.SelectedItem.ToString() + "</b> with the identifier: ";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            if (rblOptions.SelectedItem.ToString().Equals("Official"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = false;
                ddlAppleTV.Visible = false;
                ddlAudioAccessory.Visible = false;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }
            else if (rblOptions.SelectedItem.ToString().Equals("OTA"))
            {
                lblStep2.Visible = true;
                ddliPhone.Visible = true;
                ddliPad.Visible = true;
                ddliPod.Visible = true;
                ddlWatch.Visible = true;
                ddlAppleTV.Visible = true;
                ddlAudioAccessory.Visible = true;
                ddlVersion.Visible = false;
                ddlVersionOTA.Visible = false;
            }


        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (rblOptions.SelectedItem.Value.Equals("Version"))
            {
                string version = ddlVersion.SelectedItem.ToString();
                string versionJSON = "";

                WebClient webClientVersion = new WebClient();
                versionJSON = webClientVersion.DownloadString("https://api.ipsw.me/v4/ipsw/" + version);
                dynamic jsonVersionObj = JsonConvert.DeserializeObject(versionJSON);
                TableHeaderRow thrVersion = new TableHeaderRow();
                TableHeaderCell tableHeaderIdentifier = new TableHeaderCell();
                TableHeaderCell tableHeaderBuildID = new TableHeaderCell();
                TableHeaderCell tableHeaderURL = new TableHeaderCell();
                TableHeaderCell tableHeaderFileSize = new TableHeaderCell();
                TableHeaderCell tableHeaderReleasedDate = new TableHeaderCell();

                tableHeaderIdentifier.Text = "Identifier";
                tableHeaderBuildID.Text = "Build ID";
                tableHeaderURL.Text = "Download Links";
                tableHeaderFileSize.Text = "File Size";
                tableHeaderReleasedDate.Text = "Released Date";

                thrVersion.Cells.Add(tableHeaderIdentifier);
                thrVersion.Cells.Add(tableHeaderBuildID);
                thrVersion.Cells.Add(tableHeaderURL);
                thrVersion.Cells.Add(tableHeaderFileSize);
                thrVersion.Cells.Add(tableHeaderReleasedDate);
                tblData.Rows.AddAt(0, thrVersion);
                lblSelectionComment.Text += "<br/>There are " + jsonVersionObj.Count + " Files";

                for (int i = 0; i < jsonVersionObj.Count; i++)
                {
                    string identifier = jsonVersionObj[i]["identifier"];
                    string buildID = jsonVersionObj[i]["buildid"];
                    string url = jsonVersionObj[i]["url"];
                    string fileSize = jsonVersionObj[i]["filesize"];
                    string releaseDate = jsonVersionObj[i]["releasedate"];

                    HyperLink hyperIdentifier = new HyperLink();
                    HyperLink hyperBuildID = new HyperLink();
                    HyperLink hyperURL = new HyperLink();
                    HyperLink hyperFileSize = new HyperLink();
                    HyperLink hyperReleaseDate = new HyperLink();

                    hyperIdentifier.ID = "hypIdentifier" + i;
                    hyperBuildID.ID = "hyperBuildID" + i;
                    hyperURL.ID = "hyperURL" + i;
                    hyperFileSize.ID = "hyperFileSize" + i;
                    hyperReleaseDate.ID = "hyperReleaseDate" + i;


                    hyperIdentifier.Text = identifier + "<br/>";
                    hyperBuildID.Text = buildID + "<br/>";
                    hyperURL.Text = url + "<br/>";
                    double fileSizeGB = Double.Parse(fileSize) / 1024 / 1024 / 1024;
                    hyperFileSize.Text = fileSizeGB.ToString("0.##") + " GB";
                    if (!(releaseDate is null))
                    {
                        hyperReleaseDate.Text = releaseDate;
                    }
                    else
                    {
                        hyperReleaseDate.Text = "-";
                    }


                    hyperURL.NavigateUrl = url;

                    string[] links = url.Split('/');
                    int linkInt = links.Length - 1;
                    hyperURL.Text = links[linkInt] + "<br/>";

                    tblData.BorderStyle = BorderStyle.Solid;

                    TableRow tr = new TableRow();
                    TableCell tdIdentifier = new TableCell();
                    TableCell tdBuildID = new TableCell();
                    TableCell tdURL = new TableCell();
                    TableCell tdFileSize = new TableCell();
                    TableCell tdReleaseDate = new TableCell();

                    tdIdentifier.Controls.Add(hyperIdentifier);
                    tdBuildID.Controls.Add(hyperBuildID);
                    tdURL.Controls.Add(hyperURL);
                    tdFileSize.Controls.Add(hyperFileSize);
                    tdReleaseDate.Controls.Add(hyperReleaseDate);

                    tr.Cells.Add(tdIdentifier);
                    tr.Cells.Add(tdBuildID);
                    tr.Cells.Add(tdURL);
                    tr.Cells.Add(tdFileSize);
                    tr.Cells.Add(tdReleaseDate);
                    tblData.Rows.Add(tr);
                }
            }

            else if (rblOptions.SelectedItem.Value.Equals("Version (OTA)"))
            {
                string versionOTA = ddlVersionOTA.SelectedItem.ToString();
                string versionOTAJSON = "";

                WebClient webClientVersionOTA = new WebClient();
                versionOTAJSON = webClientVersionOTA.DownloadString("https://api.ipsw.me/v4/ota/" + versionOTA);
                dynamic jsonVersionOTAObj = JsonConvert.DeserializeObject(versionOTAJSON);
                TableHeaderRow thrVersionOTA = new TableHeaderRow();
                TableHeaderCell tableHeaderIdentifierOTA = new TableHeaderCell();
                TableHeaderCell tableHeaderBuildIDOTA = new TableHeaderCell();
                TableHeaderCell tableHeaderURLOTA = new TableHeaderCell();
                TableHeaderCell tableHeaderFileSizeOTA = new TableHeaderCell();
                TableHeaderCell tableHeaderReleasedDateOTA = new TableHeaderCell();

                tableHeaderIdentifierOTA.Text = "Identifier";
                tableHeaderBuildIDOTA.Text = "Build ID";
                tableHeaderURLOTA.Text = "Download Links";
                tableHeaderFileSizeOTA.Text = "File Size";
                tableHeaderReleasedDateOTA.Text = "Released Date";

                thrVersionOTA.Cells.Add(tableHeaderIdentifierOTA);
                thrVersionOTA.Cells.Add(tableHeaderBuildIDOTA);
                thrVersionOTA.Cells.Add(tableHeaderURLOTA);
                thrVersionOTA.Cells.Add(tableHeaderFileSizeOTA);
                thrVersionOTA.Cells.Add(tableHeaderReleasedDateOTA);
                tblData.Rows.AddAt(0, thrVersionOTA);
                lblSelectionComment.Text += "<br/>There are " + jsonVersionOTAObj.Count + " Files";

                for (int i = 0; i < jsonVersionOTAObj.Count; i++)
                {
                    string identifier = jsonVersionOTAObj[i]["identifier"];
                    string buildID = jsonVersionOTAObj[i]["buildid"];
                    string url = jsonVersionOTAObj[i]["url"];
                    string fileSize = jsonVersionOTAObj[i]["filesize"];
                    string releaseDate = jsonVersionOTAObj[i]["releasedate"];

                    HyperLink hyperIdentifierOTA = new HyperLink();
                    HyperLink hyperBuildIDOTA = new HyperLink();
                    HyperLink hyperURLOTA = new HyperLink();
                    HyperLink hyperFileSizeOTA = new HyperLink();
                    HyperLink hyperReleaseDateOTA = new HyperLink();

                    hyperIdentifierOTA.ID = "hypIdentifier" + i;
                    hyperBuildIDOTA.ID = "hyperBuildID" + i;
                    hyperURLOTA.ID = "hyperURL" + i;
                    hyperFileSizeOTA.ID = "hyperFileSize" + i;
                    hyperReleaseDateOTA.ID = "hyperReleaseDate" + i;


                    hyperIdentifierOTA.Text = identifier + "<br/>";
                    hyperBuildIDOTA.Text = buildID + "<br/>";
                    hyperURLOTA.Text = url + "<br/>";
                    double fileSizeGB = Double.Parse(fileSize) / 1024 / 1024 / 1024;
                    hyperFileSizeOTA.Text = fileSizeGB.ToString("0.##") + " GB";
                    if (!(releaseDate is null))
                    {
                        hyperReleaseDateOTA.Text = releaseDate;
                    }
                    else
                    {
                        hyperReleaseDateOTA.Text = "-";
                    }


                    hyperURLOTA.NavigateUrl = url;

                    string[] links = url.Split('/');
                    int linkInt = links.Length - 1;
                    hyperURLOTA.Text = links[linkInt] + "<br/>";

                    tblData.BorderStyle = BorderStyle.Solid;

                    TableRow tr = new TableRow();
                    TableCell tdIdentifierOTA = new TableCell();
                    TableCell tdBuildIDOTA = new TableCell();
                    TableCell tdURLOTA = new TableCell();
                    TableCell tdFileSizeOTA = new TableCell();
                    TableCell tdReleaseDateOTA = new TableCell();

                    tdIdentifierOTA.Controls.Add(hyperIdentifierOTA);
                    tdBuildIDOTA.Controls.Add(hyperBuildIDOTA);
                    tdURLOTA.Controls.Add(hyperURLOTA);
                    tdFileSizeOTA.Controls.Add(hyperFileSizeOTA);
                    tdReleaseDateOTA.Controls.Add(hyperReleaseDateOTA);

                    tr.Cells.Add(tdIdentifierOTA);
                    tr.Cells.Add(tdBuildIDOTA);
                    tr.Cells.Add(tdURLOTA);
                    tr.Cells.Add(tdFileSizeOTA);
                    tr.Cells.Add(tdReleaseDateOTA);
                    tblData.Rows.Add(tr);
                }
            }

            else
            {

                string identifier = lblSelection.Text;
                string firmwareType = rblOptions.SelectedItem.ToString();
                string myJSON = "";

                WebClient webClient = new WebClient();
                if (firmwareType.Equals("Official"))
                {
                    myJSON = webClient.DownloadString("https://api.ipsw.me/v4/device/" + identifier + "?type=ipsw");
                }
                else if (firmwareType.Equals("OTA"))
                {
                    myJSON = webClient.DownloadString("https://api.ipsw.me/v4/device/" + identifier + "?type=ota");
                }


                dynamic jsonObj = JsonConvert.DeserializeObject(myJSON);

                TableHeaderRow thr = new TableHeaderRow();
                TableHeaderCell headerTableCell0 = new TableHeaderCell();
                TableHeaderCell headerTableCell2 = new TableHeaderCell();
                TableHeaderCell headerTableCell3 = new TableHeaderCell();
                TableHeaderCell headerTableCell4 = new TableHeaderCell();

                headerTableCell0.Text = "Build ID";
                headerTableCell2.Text = "Links";
                headerTableCell3.Text = "Release Date & Time";
                headerTableCell4.Text = "File Size";

                thr.Cells.Add(headerTableCell0);
                thr.Cells.Add(headerTableCell2);
                thr.Cells.Add(headerTableCell4);
                thr.Cells.Add(headerTableCell3);
                tblData.Rows.AddAt(0, thr);
                lblSelectionComment.Text += "<br/>There are " + jsonObj["firmwares"].Count + " Files";

                for (int i = 0; i < jsonObj["firmwares"].Count; i++)
                {
                    string buildid = jsonObj["firmwares"][i]["buildid"].ToString();
                    string url = jsonObj["firmwares"][i]["url"].ToString();
                    string dateReleased = jsonObj["firmwares"][i]["releasedate"].ToString();
                    string fileSize = jsonObj["firmwares"][i]["filesize"].ToString();


                    HyperLink hypName = new HyperLink();
                    HyperLink hyp = new HyperLink();
                    HyperLink hypDateReleased = new HyperLink();
                    HyperLink hypFileSize = new HyperLink();

                    hypName.ID = "hypName" + i;
                    hypName.Text = buildid + "<br/>";

                    hyp.ID = "hypABD" + i;
                    hyp.NavigateUrl = url;

                    hypFileSize.ID = "hypFileSize" + i;
                    double fileSizeGB = Double.Parse(fileSize) / 1024 / 1024 / 1024;
                    hypFileSize.Text = fileSizeGB.ToString("0.##") + " GB";


                    string[] links = url.Split('/');
                    int linkInt = links.Length - 1;
                    hyp.Text = links[linkInt] + "<br/>";

                    hypDateReleased.ID = "hypDateReleased" + i;
                    if (!dateReleased.Equals(""))
                    {
                        DateTime dr = Convert.ToDateTime(dateReleased);
                        hypDateReleased.Text = dr.ToLongDateString().ToString() + " " + dr.ToLongTimeString().ToString();
                    }
                    else
                    {
                        hypDateReleased.Text = "-";
                    }


                    tblData.BorderStyle = BorderStyle.Solid;

                    TableRow tr = new TableRow();
                    TableCell tdName = new TableCell();
                    TableCell tdLinks = new TableCell();
                    TableCell tdHyperFileSize = new TableCell();
                    TableCell tdDateReleased = new TableCell();

                    tdName.Controls.Add(hypName);
                    tdLinks.Controls.Add(hyp);
                    tdHyperFileSize.Controls.Add(hypFileSize);
                    tdDateReleased.Controls.Add(hypDateReleased);

                    tr.Cells.Add(tdName);
                    tr.Cells.Add(tdLinks); ;
                    tr.Cells.Add(tdHyperFileSize);
                    tr.Cells.Add(tdDateReleased);
                    tblData.Rows.Add(tr);
                }
            }
        }

        protected void ddlVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelection.Text = ddlVersion.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected iOS <b>" + rblOptions.SelectedItem.ToString() + " " + ddlVersion.SelectedItem.ToString() + "</b>";
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            lblStep2.Visible = true;
            ddliPhone.Visible = false;
            ddliPad.Visible = false;
            ddliPod.Visible = false;
            ddlWatch.Visible = false;
            ddlAppleTV.Visible = false;
            ddlAudioAccessory.Visible = false;
            ddlVersion.Visible = true;
            ddlVersionOTA.Visible = false;
        }

        protected void ddlVersionOTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelection.Text = ddlVersionOTA.SelectedValue.ToString();
            lblSelection.Font.Bold = true;
            lblSelection.Font.Size = 15;

            lblSelectionComment.Text = "You have selected OTA <b>" + rblOptions.SelectedItem.ToString() + " " + ddlVersionOTA.SelectedItem.ToString();
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.Visible = true;

            lblStep3.Visible = true;
            lblStep3.Font.Bold = true;

            lblStep2.Visible = true;
            ddliPhone.Visible = false;
            ddliPad.Visible = false;
            ddliPod.Visible = false;
            ddlWatch.Visible = false;
            ddlAppleTV.Visible = false;
            ddlAudioAccessory.Visible = false;
            ddlVersion.Visible = false;
            ddlVersionOTA.Visible = true;
        }
    }
}