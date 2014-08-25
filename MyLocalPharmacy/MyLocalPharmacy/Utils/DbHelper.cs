using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MyLocalPharmacy.Entities;
using MyLocalPharmacy.LocalDataBase;

namespace MyLocalPharmacy.Helper
{
    public class DbHelper
    {

        #region constants

        // private static const string _connectionstring = "isostore:/WvConference14.sdf";

        #endregion

        #region Public Methods

        /// <summary>
        /// Get Connection string.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return "isostore:/WvConference16.sdf";
        }

        #region Validations

        /// <summary>
        /// Checking existance of Conference.
        /// </summary>
        /// <param name="confernceId"></param>
        /// <returns></returns>
        public static bool IsConfernceItemExist(string confernceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Conferences.FirstOrDefault(x => x.ConferenceId == confernceId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Track.
        /// </summary>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public static bool IsTrackItemExist(int trackId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Tracks.FirstOrDefault(x => x.TrackId == trackId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Speaker.
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        public static bool IsSpeakerExist(int speakerId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Speakers.FirstOrDefault(x => x.SpeakerId == speakerId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Sponsor.
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        public static bool IsSponserExist(int sponserId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Sponsors.FirstOrDefault(x => x.SponsorId == sponserId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Mssage.
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        public static bool IsMessageExist(int messageId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Messages.FirstOrDefault(x => x.MessageId == messageId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Info.
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        public static bool IsInfoExist(int infoId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.RelatedInformations.FirstOrDefault(x => x.RelatedInformationsId == infoId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Sponsor level.
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        public static bool IsSponserLevelExist(int sponserLevelId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.SponsorLevels.FirstOrDefault(x => x.SponsorlevelId == sponserLevelId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Session.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public static bool IsSessionExist(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Sessions.FirstOrDefault(x => x.SessionId == sessionId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Attendee.
        /// </summary>
        /// <param name="attendeeId"></param>
        /// <returns></returns>
        public static bool IsAttendeeExist(int attendeeId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Attendees.FirstOrDefault(x => x.AttendeeId == attendeeId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Tab.
        /// </summary>
        /// <param name="_tabName"></param>
        /// <returns></returns>
        public static bool IsTabMasterItemExist(string tabId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.TabMasters.FirstOrDefault(x => x.TabId == tabId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Conference_Tab
        /// </summary>
        /// <param name="confernceId"></param>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public static bool IsConfernce_TabItemExist(string confernceId, string tabId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Conference_Tabs.FirstOrDefault(x => x.Conference_Id == confernceId && x.Tab_Id == tabId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Speaker_Session
        /// </summary>
        /// <param name="confernceId"></param>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public static bool IsSpeaker_SessionItemExist(int sessionId, int speakerId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Speaker_Sessions.FirstOrDefault(x => x.Spkr_SessionId == sessionId && x.Spkr_Id == speakerId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checking existance of Track_Session
        /// </summary>
        /// <param name="confernceId"></param>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public static bool IsTrack_SessionItemExist(int sessionId, int trackId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    return (db.Session_Tracks.FirstOrDefault(x => x.Session_Id == sessionId && x.Track_Id == trackId) != null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Insertion and Updation


        /// <summary>
        /// Inserting a conference to database.
        /// </summary>
        /// <param name="confrDetails">Conference Details</param>
        public static void InsertConferenceToDatabase(ConferenceDetails confrDetails, string sessiontoken, BitmapImage confrImage)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<TabMaster> tabList = new List<TabMaster>();
                    List<Conference_Tab> confrTabList = new List<Conference_Tab>();

                    if (!DbHelper.IsConfernceItemExist(confrDetails.ConferenceId))
                    {
                        Conference objConference = new Conference
                        {
                            ConferenceId = confrDetails.ConferenceId,
                            Description = confrDetails.Description,
                            IsAdded = true,
                            SessionToken = sessiontoken,
                            RequiresPin = confrDetails.RequiresPin,
                            AppLocation = confrDetails.ApplicationLocationName,
                            CenterId = confrDetails.ConferenceCenterId,
                            ContactName = confrDetails.ContactName,
                            ContactPhone = confrDetails.ContactPhone,
                            ContactTitle = confrDetails.ContactTitle,
                            EndDate = TimeZoneInfo.ConvertTime(confrDetails.EndDate, TimeZoneInfo.Utc),
                            StartDate = TimeZoneInfo.ConvertTime(confrDetails.StartDate, TimeZoneInfo.Utc),
                            TwtrHashTag = confrDetails.TwitterHashTag,
                            WebSite = confrDetails.Website,
                            TimeZone = confrDetails.TimeZoneId,
                            Name = confrDetails.Name,
                            Location = confrDetails.LocationName,
                            LocationAddress1 = confrDetails.LocationAddress1,
                            LocationAddress2 = confrDetails.LocationAddress2,
                            LocationCity = confrDetails.LocationCity,
                            LocationState = confrDetails.LocationState,
                            LocationZip = confrDetails.LocationZip,
                            OrganizationId = confrDetails.OrganizationId,
                            ImageUrl = confrDetails.ConferenceImageUrl,
                            IsCurrent = confrDetails.IsCurrent,
                            TracksEnabled = confrDetails.TracksEnabled
                        };
                        foreach (Tab _tab in confrDetails.Tabs)
                        {
                            if (!DbHelper.IsTabMasterItemExist(_tab.TabId))
                            {
                                TabMaster tabMaster = new TabMaster()
                                {
                                    TabId = _tab.TabId,
                                    Tab_Name = _tab.DisplayName,

                                };
                                tabList.Add(tabMaster);

                            }
                            if (!DbHelper.IsConfernce_TabItemExist(confrDetails.ConferenceId, _tab.TabId))
                            {
                                Conference_Tab confTab = new Conference_Tab()
                                {
                                    Tab_Id = _tab.TabId,
                                    Conference_Id = confrDetails.ConferenceId,
                                    Order = _tab.DisplayOrder,
                                    IsVisible = _tab.IsVisible,
                                    Version = _tab.Version
                                };
                                confrTabList.Add(confTab);
                            }

                        }
                        // Add the new object to the Orders collection.
                        db.Conferences.InsertOnSubmit(objConference);
                        db.TabMasters.InsertAllOnSubmit(tabList);
                        db.Conference_Tabs.InsertAllOnSubmit(confrTabList);
                        // Submit the change to the database.
                        db.SubmitChanges();
                    }
                    if (confrImage != null)
                    {
                        try
                        {
                            IsoStoreHelper.SaveImage(confrImage, confrDetails.ConferenceId);
                        }
                        catch (Exception e)
                        {


                        }
                    }

                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Insert Conference Tab relationship.
        /// </summary>
        /// <param name="confrDetails"></param>
        /// <param name="db"></param>
        public static void InsertConferenceTabrelationship(ConferenceDetails confrDetails, WvConferenceContext db)
        {
            try
            {

                List<Conference_Tab> confrTabList = new List<Conference_Tab>();
                var tabMasterList = from tabs in db.TabMasters
                                    select tabs;
                foreach (Tab _tab in confrDetails.Tabs)
                {
                    string _tabId = tabMasterList.FirstOrDefault(x => x.Tab_Name == _tab.DisplayName).TabId;
                    if (!DbHelper.IsConfernce_TabItemExist(confrDetails.ConferenceId, _tabId))
                    {
                        Conference_Tab confTab = new Conference_Tab()
                        {
                            Tab_Id = _tabId,
                            Conference_Id = confrDetails.ConferenceId,
                            Order = _tab.DisplayOrder
                        };
                        confrTabList.Add(confTab);
                    }
                }

                db.Conference_Tabs.InsertAllOnSubmit(confrTabList);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Conference tracks.
        /// </summary>
        /// <param name="trackDetails"></param>
        /// <param name="db"></param>
        public static void InsertTracks(List<TracksDetails> trackDetails, string conferenceId)
        {
            try
            {
                int trackDetailsCount = (trackDetails != null )?trackDetails.Count:0;
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Track> trackList = new List<Track>();
                    ObservableCollection<Track> tracksInDb = GetConferenceTracks(conferenceId);
                    foreach (TracksDetails track in trackDetails)
                    {
                        Track confTrack = null;
                        if (!DbHelper.IsTrackItemExist(track.TrackId))
                        {
                            //Insersion.
                            confTrack = new Track()
                            {
                                TrackId = track.TrackId,
                                Track_ConfId = conferenceId,
                                Track_Body = track.Name,
                                Track_Color = track.Color,
                                DisplayOrder = track.DisplayOrder
                            };
                            trackList.Add(confTrack);
                        }
                        else
                        {
                            //Updation.
                            using (WvConferenceContext db1 = new WvConferenceContext(connection))
                            {
                                confTrack = DbHelper.GetTrack(track.TrackId,db1);
                                confTrack.TrackId = track.TrackId;
                                confTrack.Track_ConfId = conferenceId;
                                confTrack.Track_Body = track.Name;
                                confTrack.Track_Color = track.Color;
                                confTrack.DisplayOrder = track.DisplayOrder;
                                db1.SubmitChanges();
                            }
                        }
                       
                    }

                    db.Tracks.InsertAllOnSubmit(trackList);
                    db.SubmitChanges();

                    //Deleting removed tracks in conference.
                    if (tracksInDb != null && tracksInDb.Count > trackDetailsCount)
                    {
                        foreach (Track selectedTrack in tracksInDb)
                        {
                            var item = from tracks in trackDetails
                                       where tracks.TrackId == selectedTrack.TrackId
                                       select tracks;
                            TracksDetails trackDetail = (TracksDetails)item.FirstOrDefault();
                            if (trackDetail == null)
                            {
                                DeleteSessionTrack(selectedTrack.TrackId);
                                DeleteConferenceTracks(conferenceId, selectedTrack.TrackId);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Attendees.
        /// </summary>
        /// <param name="attendeeDetails"></param>
        /// <param name="db"></param>
        public static void InsertAttendees(List<AttendeeDetails> attendeeDetails)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Attendee> attendeeList = new List<Attendee>();

                    foreach (AttendeeDetails attendeeDetail in attendeeDetails)
                    {
                        Attendee attendee = null;
                        DeleteSessionAttendee(attendeeDetail.SessionId);
                        if (!DbHelper.IsAttendeeExist(attendeeDetail.CheckInId))
                        {
                            if (DbHelper.IsSessionExist(attendeeDetail.SessionId))
                            {
                                attendee = new Attendee()
                                {
                                    AttendeeId = attendeeDetail.CheckInId,
                                    Attendee_SessionId = attendeeDetail.SessionId,
                                    Attendees_Email = attendeeDetail.Email,
                                    Attendees_FbLink = attendeeDetail.FacebookLink,
                                    Attendees_ImageUrl = attendeeDetail.ImageUrl,
                                    Attendees_Name = attendeeDetail.Name,
                                    Attendees_Phone = attendeeDetail.PhoneNumber,
                                    Attendees_Summary = attendeeDetail.Description,
                                    Attendees_TwtrLink = attendeeDetail.TwitterLink

                                };
                                attendeeList.Add(attendee);
                            }
                        }
                        else
                        {
                            attendee = DbHelper.GetAttendee(attendeeDetail.CheckInId);
                            attendee.AttendeeId = attendeeDetail.CheckInId;
                            attendee.Attendee_SessionId = attendeeDetail.SessionId;
                            attendee.Attendees_Email = attendeeDetail.Email;
                            attendee.Attendees_FbLink = attendeeDetail.FacebookLink;
                            attendee.Attendees_ImageUrl = attendeeDetail.ImageUrl;
                            attendee.Attendees_Name = attendeeDetail.Name;
                            attendee.Attendees_Phone = attendeeDetail.PhoneNumber;
                            attendee.Attendees_Summary = attendeeDetail.Description;
                            attendee.Attendees_TwtrLink = attendeeDetail.TwitterLink;
                            db.SubmitChanges();
                        }
                    }

                    db.Attendees.InsertAllOnSubmit(attendeeList);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Speakers.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertSpeakers(List<SpeakersDetails> speakersDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Speaker> speakerList = new List<Speaker>();
                    foreach (SpeakersDetails speakerDetail in speakersDetails)
                    {

                        if (!DbHelper.IsSpeakerExist(speakerDetail.SpeakerId))
                        {
                            Speaker speaker = new Speaker()
                            {
                                SpeakerId = speakerDetail.SpeakerId,
                                Spkr_Company = speakerDetail.Company,
                                Spkr_ImageUrl = speakerDetail.SpeakerImage,
                                Spkr_Name = speakerDetail.Name,
                                Spkr_Summary = speakerDetail.Description,
                                Spkr_Title = speakerDetail.Title,
                                Spkr_Email = speakerDetail.Email,
                                Spkr_FbLink = speakerDetail.FacebookUrl,
                                Spkr_Phone = speakerDetail.Phone,
                                Spkr_TwtrLink = speakerDetail.Twitter

                            };
                            speakerList.Add(speaker);
                        }
                        else
                        {
                            using (WvConferenceContext db1 = new WvConferenceContext(connection))
                            {
                                Speaker speaker = DbHelper.GetSpeaker(speakerDetail.SpeakerId,db1);
                                speaker.SpeakerId = speakerDetail.SpeakerId;
                                speaker.Spkr_Company = speakerDetail.Company;
                                speaker.Spkr_ImageUrl = speakerDetail.SpeakerImage;
                                speaker.Spkr_Name = speakerDetail.Name;
                                speaker.Spkr_Summary = speakerDetail.Description;
                                speaker.Spkr_Title = speakerDetail.Title;
                                speaker.Spkr_Email = speakerDetail.Email;
                                speaker.Spkr_FbLink = speakerDetail.FacebookUrl;
                                speaker.Spkr_Phone = speakerDetail.Phone;
                                speaker.Spkr_TwtrLink = speakerDetail.Twitter;
                                db1.SubmitChanges();
                            }
                        }
                    }

                    db.Speakers.InsertAllOnSubmit(speakerList);
                    db.SubmitChanges();
                }
                InsertSpeaker_ConferenceRelation(speakersDetails, conferenceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Speaker Conference Relation.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertSpeaker_ConferenceRelation(List<SpeakersDetails> speakerDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Conference_Speaker> spkr_confr_relatns = new List<Conference_Speaker>();
                    DeleteSpeakerConferenceRelation(conferenceId);
                    foreach (SpeakersDetails speakerDetail in speakerDetails)
                    {                        
                        Conference_Speaker spLevel = new Conference_Speaker()
                        {
                            Speaker_Id = speakerDetail.SpeakerId,
                            Conference_Id = conferenceId,
                        };
                        spkr_confr_relatns.Add(spLevel);

                    }
                    db.Conference_Speakers.InsertAllOnSubmit(spkr_confr_relatns);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Sponsors.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertSponsers(List<SponsorDetails> sponsorDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Sponsor> sponsorList = new List<Sponsor>();
                    List<Sponsor_SponsorLevel> spLevels = new List<Sponsor_SponsorLevel>();
                    ObservableCollection<Sponsor> sponsorsInDB = GetConferenceSponser(conferenceId);
                    foreach(Sponsor sponsor in sponsorsInDB)
                    {
                        DeleteSponserSponserLevelRelation(sponsor.SponsorId);
                    }
                    DeleteConferenceSponsers(conferenceId);                    
                    foreach (SponsorDetails sponserDetail in sponsorDetails)
                    {

                        if (!DbHelper.IsSponserExist(sponserDetail.SponsorId))
                        {
                            Sponsor sponser = new Sponsor()
                            {
                                SponsorId = sponserDetail.SponsorId,
                                Sponsor_ConfId = conferenceId,
                                Sponsor_Website = sponserDetail.Website,
                                Sponsor_Name = sponserDetail.Name,
                                Sponsor_Summary = sponserDetail.Description,
                                Sponsor_Email = sponserDetail.Email,
                                Sponsor_FbLink = sponserDetail.FacebookUrl,
                                Sponsor_ImageUrl = sponserDetail.ImageUrl,
                                Sponsor_TwtrLink = sponserDetail.Twitter,
                                Sponsor_Phone = sponserDetail.Phone


                            };
                            sponsorList.Add(sponser);
                        }
                        else
                        {
                            using (WvConferenceContext db1 = new WvConferenceContext(connection))
                            {
                                Sponsor sponser = DbHelper.GetSponser(sponserDetail.SponsorId,db1);
                                sponser.SponsorId = sponserDetail.SponsorId;
                                sponser.Sponsor_ConfId = conferenceId;
                                sponser.Sponsor_Website = sponserDetail.Website;
                                sponser.Sponsor_Name = sponserDetail.Name;
                                sponser.Sponsor_Summary = sponserDetail.Description;
                                sponser.Sponsor_Email = sponserDetail.Email;
                                sponser.Sponsor_FbLink = sponserDetail.FacebookUrl;
                                sponser.Sponsor_ImageUrl = sponserDetail.ImageUrl;
                                sponser.Sponsor_TwtrLink = sponserDetail.Twitter;
                                sponser.Sponsor_Phone = sponserDetail.Phone;
                                db1.SubmitChanges();
                            }
                        }
                    }

                    db.Sponsors.InsertAllOnSubmit(sponsorList);
                    db.SubmitChanges();
                }
                InsertSponser_SponserLevelRelation(sponsorDetails, conferenceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Messages.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertMessages(List<MessageDetails> messageDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                List<int> messageToDelete = new List<int>();
                List<int> readedMessages = GetConferenceReadMessage(conferenceId);
                List<int> allMessageIds = GetConferenceMessageIds(conferenceId);
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Message> messageList = new List<Message>();
                    foreach (MessageDetails messageDetail in messageDetails)
                    {

                        if (!DbHelper.IsMessageExist(messageDetail.MessageId))
                        {
                            Message message = new Message()
                            {
                                MessageId = messageDetail.MessageId,
                                Message_ConfId = conferenceId,
                                Message_subject = messageDetail.Subject,
                                Message_Body = messageDetail.Body,
                                Message_Date = TimeZoneInfo.ConvertTime(messageDetail.SendDate, TimeZoneInfo.Utc),
                                Read = false,
                                NonHtml_Body = messageDetail.NonHtmlBody
                            };
                            messageList.Add(message);
                        }
                        else
                        {
                            Message message = DbHelper.GetMessage(messageDetail.MessageId,db);
                            message.MessageId = messageDetail.MessageId;
                            message.Message_ConfId = conferenceId;
                            message.Message_subject = messageDetail.Subject;
                            message.Message_Body = messageDetail.Body;
                            message.Message_Date = TimeZoneInfo.ConvertTime(messageDetail.SendDate, TimeZoneInfo.Utc);
                            message.NonHtml_Body = messageDetail.NonHtmlBody;
                            db.SubmitChanges();
                        }
                        messageToDelete.Add(messageDetail.MessageId);
                        
                    }

                    db.Messages.InsertAllOnSubmit(messageList);
                    db.SubmitChanges();
                    if (messageDetails == null || messageDetails.Count == 0)
                    {
                        foreach (int id in allMessageIds)
                        {
                            Message message = DbHelper.GetMessage(id, db);
                            db.Messages.DeleteOnSubmit(message);
                            db.SubmitChanges();

                        }
                    }
                    else
                    {
                        foreach (int id in allMessageIds)
                        {
                            if (messageToDelete != null && messageToDelete.Count > 0 && !messageToDelete.Contains(id))
                            {
                                Message message = DbHelper.GetMessage(id, db);
                                db.Messages.DeleteOnSubmit(message);
                                db.SubmitChanges();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Informations.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertInfo(List<InfoDetails> infoDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                DeleteConferenceInfo(conferenceId);
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<RelatedInformation> infoList = new List<RelatedInformation>();
                    foreach (InfoDetails infoDetail in infoDetails)
                    {

                        if (!DbHelper.IsInfoExist(infoDetail.InformationId))
                        {
                            RelatedInformation info = new RelatedInformation()
                            {
                                RelatedInformationsId = infoDetail.InformationId,
                                Info_ConfId = conferenceId,
                                Info_Subject = infoDetail.Title,
                                Info_Body = infoDetail.Body,
                                Image = infoDetail.Info_ImageUrl
                            };
                            infoList.Add(info);
                        }
                        else
                        {
                            RelatedInformation info = DbHelper.GetInfo(infoDetail.InformationId);
                            info.RelatedInformationsId = infoDetail.InformationId;
                            info.Info_ConfId = conferenceId;
                            info.Info_Subject = infoDetail.Title;
                            info.Info_Body = infoDetail.Body;
                            db.SubmitChanges();
                        }
                    }

                    db.RelatedInformations.InsertAllOnSubmit(infoList);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert About details.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertAbout(AboutDetails aboutDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                DeleteConferenceAbout(conferenceId);
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    About about = new About()
                    {
                        About_Body = aboutDetails.Body,
                        About_ConfId = conferenceId,
                        About_Website = aboutDetails.Website,
                        About_CompanyName = aboutDetails.CompanyName,
                        About_Image = aboutDetails.AboutImage,
                        About_Email = aboutDetails.Email,
                        About_Phone = aboutDetails.Phone
                    };

                    db.Abouts.InsertOnSubmit(about);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Speakers relation with sponser levels.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertSponser_SponserLevelRelation(List<SponsorDetails> sponsorDetails, string conferenceId)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<Sponsor_SponsorLevel> spLevels = new List<Sponsor_SponsorLevel>();

                    foreach (SponsorDetails sponserDetail in sponsorDetails)
                    {
                        DeleteSponserSponserLevelRelation(sponserDetail.SponsorId, conferenceId);
                        Sponsor_SponsorLevel spLevel = new Sponsor_SponsorLevel();
                        spLevel.Sponsor_Id = sponserDetail.SponsorId;
                        if (sponserDetail.SponsorLevelId != 0)
                        {
                            if (sponserDetail.SponsorLevelType == "Gold")
                                spLevel.SponsorLevel_Id = 49;
                            if (sponserDetail.SponsorLevelType == "Silver")
                                spLevel.SponsorLevel_Id = 50;
                            if (sponserDetail.SponsorLevelType == "Bronze")
                                spLevel.SponsorLevel_Id = 51;
                        }
                        else
                        {
                            spLevel.SponsorLevel_Id = 51;
                        }
                        spLevels.Add(spLevel);

                    }
                    db.Sponsor_SponsorLevels.InsertAllOnSubmit(spLevels);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Sponser levels.
        /// </summary>
        /// <param name="speakersDetails"></param>
        /// <param name="db"></param>
        public static void InsertSponserLevels(List<SponsorLevelDetails> sponsorLevelDetails)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    List<SponsorLevel> sponsorLevelList = new List<SponsorLevel>();
                    foreach (SponsorLevelDetails sponserLevelDetail in sponsorLevelDetails)
                    {

                        if (!DbHelper.IsSponserLevelExist(sponserLevelDetail.SponsorLevelId))
                        {
                            SponsorLevel sponserLevel = new SponsorLevel()
                            {
                                SponsorlevelId = sponserLevelDetail.SponsorLevelId,
                                SponsorLevel_Name = sponserLevelDetail.Name,
                                SponsorLevel_Type = sponserLevelDetail.SponsorLevelType

                            };
                            sponsorLevelList.Add(sponserLevel);
                        }
                        else
                        {
                            SponsorLevel sponserLevel = DbHelper.GetSponserLevel(sponserLevelDetail.SponsorLevelId,db);
                            sponserLevel.SponsorlevelId = sponserLevelDetail.SponsorLevelId;
                            sponserLevel.SponsorLevel_Name = sponserLevelDetail.Name;
                            sponserLevel.SponsorLevel_Type = sponserLevelDetail.SponsorLevelType;
                            db.SubmitChanges();
                        }
                    }

                    db.SponsorLevels.InsertAllOnSubmit(sponsorLevelList);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Sessions.
        /// </summary>
        /// <param name="sessionsDetails"></param>
        /// <param name="db"></param>
        public static void InsertSessions(List<SessionDetails> sessionsDetails, string conferenceId, bool IsTrackEnabled)
        {
            try
            {
                string connection = DbHelper.GetConnectionString();
                List<Session> sessionList = new List<Session>();
                List<int> sessionMineList = new List<int>();

                ObservableCollection<Session> sessionInDb = GetConferenceSessions(conferenceId);
                foreach (Session session in sessionInDb)
                {
                    if (session.Mine != null && Convert.ToBoolean(session.Mine))
                    {
                        sessionMineList.Add(session.SessionId);
                    }
                    DbHelper.DeleteSessionSpeaker(session.SessionId);
                    DbHelper.DeleteSessionTracks(session.SessionId);
                    DbHelper.DeleteSession(session.SessionId);
                }
                using (WvConferenceContext db = new WvConferenceContext(connection))
                {
                    
                    foreach (SessionDetails sessionDetail in sessionsDetails)
                    {                        
                        Session session = null;
                        if (!DbHelper.IsSessionExist(sessionDetail.ScheduleId))
                        {
                            //Inserting Session Details.
                            session = new Session()
                            {
                                Session_ConfId = conferenceId,
                                SessionId = sessionDetail.ScheduleId,
                                Session_Title = sessionDetail.Title,
                                Session_StartTime = TimeZoneInfo.ConvertTime(sessionDetail.StartDate,TimeZoneInfo.Utc),
                                Sessin_EndTime = TimeZoneInfo.ConvertTime(sessionDetail.EndDate,TimeZoneInfo.Utc),
                                Description = sessionDetail.Description,
                                Mine = (sessionMineList!= null && sessionMineList.Contains(sessionDetail.ScheduleId)) ? true : false,
                                IsChecked = false,
                                Session_Location = sessionDetail.RoomName

                            };
                            sessionList.Add(session);
                        }
                        else
                        {
                            using (WvConferenceContext db3 = new WvConferenceContext(connection))
                            {
                                session = GetSessionDetails(sessionDetail.ScheduleId);
                                session.Session_ConfId = conferenceId;
                                session.SessionId = sessionDetail.ScheduleId;
                                session.Session_Title = sessionDetail.Title;
                                session.Session_StartTime = TimeZoneInfo.ConvertTime(sessionDetail.StartDate, TimeZoneInfo.Utc);
                                session.Sessin_EndTime = TimeZoneInfo.ConvertTime(sessionDetail.EndDate, TimeZoneInfo.Utc);
                                session.Description = sessionDetail.Description;
                                session.Session_Location = sessionDetail.RoomName;
                                db3.SubmitChanges();
                            }
                        }
                    }
                    db.Sessions.InsertAllOnSubmit(sessionList);
                    db.SubmitChanges();
                }

                using (WvConferenceContext db1 = new WvConferenceContext(connection))
                {
                    var trackInDB = from track in db1.Sessions
                                    select track;
                    List<Session> dsdvsd = new List<Session>(trackInDB);
                    foreach (SessionDetails sessionDetail in sessionsDetails)
                    {
                        Speaker_Session objSpkrSessn = null;
                        List<Session_Track> sessionTrackList = new List<Session_Track>();

                        //Inserting Session-Speaker Relationship 
                        DbHelper.DeleteSessionSpeaker(sessionDetail.ScheduleId);
                        if (sessionDetail.SpeakerId > 0 && !DbHelper.IsSpeaker_SessionItemExist(sessionDetail.ScheduleId, sessionDetail.SpeakerId))
                        {
                            objSpkrSessn = new Speaker_Session()
                            {
                                Spkr_Id = sessionDetail.SpeakerId,
                                Spkr_SessionId = sessionDetail.ScheduleId
                            };
                        }

                        DbHelper.DeleteSessionTracks(sessionDetail.ScheduleId);
                        //Inserting Session-Track Relationship 
                        if (IsTrackEnabled)
                        {
                            foreach (TracksDetails track in sessionDetail.Tracks)
                            {
                                if (track.TrackId == 0)
                                {
                                    ObservableCollection<Track> trackList = DbHelper.GetConferenceTracks(conferenceId);
                                    foreach (Track selectedtrack in trackList)
                                    {
                                        if (!DbHelper.IsTrack_SessionItemExist(sessionDetail.ScheduleId, selectedtrack.TrackId))
                                        {
                                            Session_Track objSessnTrack = new Session_Track()
                                            {
                                                Session_Id = sessionDetail.ScheduleId,
                                                Track_Id = selectedtrack.TrackId
                                            };
                                            sessionTrackList.Add(objSessnTrack);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!DbHelper.IsTrack_SessionItemExist(sessionDetail.ScheduleId, track.TrackId))
                                    {
                                        Session_Track objSessnTrack = new Session_Track()
                                        {
                                            Session_Id = sessionDetail.ScheduleId,
                                            Track_Id = track.TrackId
                                        };
                                        sessionTrackList.Add(objSessnTrack);
                                    }
                                }
                            }
                        }
                        if (objSpkrSessn != null)
                            db1.Speaker_Sessions.InsertOnSubmit(objSpkrSessn);
                        db1.Session_Tracks.InsertAllOnSubmit(sessionTrackList);
                        db1.SubmitChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Collection

        /// <summary>
        /// Taking List of conferences from database.
        /// </summary>
        public static ObservableCollection<Track> GetConferenceTracks(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from track in db.Tracks
                                    orderby track.DisplayOrder ascending
                                    where track.Track_ConfId == conferenceId
                                    select track;
                    ObservableCollection<Track> trackList = new ObservableCollection<Track>(trackInDB);
                    return trackList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking Conference tabs.
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <returns></returns>
        public static ObservableCollection<TabUiBinder> GetConferenceTabs(string conferenceId)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var tabInDB = from tab in db.TabMasters
                                  join conf_Tab in db.Conference_Tabs on tab.TabId equals conf_Tab.Tab_Id
                                  orderby conf_Tab.Order
                                  where conf_Tab.Conference_Id == conferenceId
                                  select new TabUiBinder() { TabId = tab.TabId, TabName = tab.Tab_Name, TabVisibility = Convert.ToBoolean(conf_Tab.IsVisible), TabVersion = (conf_Tab.Version != null) ? Convert.ToInt32(conf_Tab.Version) : 0 };
                    ObservableCollection<TabUiBinder> tabBindList = new ObservableCollection<TabUiBinder>(tabInDB);
                    return tabBindList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking List of Session  tracks from database.
        /// </summary>
        public static ObservableCollection<Session_Track> GetSessionTracks(int sessionId)
        {
            try
             {
                 using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                 {
                     var trackInDB = from track in db.Session_Tracks
                                     where track.Session_Id == sessionId
                                     select track;
                     ObservableCollection<Session_Track> trackList = new ObservableCollection<Session_Track>(trackInDB);
                     return trackList;
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        ///To fetch detail of a conference
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <returns></returns>
        public static Conference GetConferenceDetail(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conf = from conference in db.Conferences
                               where conference.ConferenceId == conferenceId
                               select conference;
                    ObservableCollection<Conference> confDetail = new ObservableCollection<Conference>(conf);
                    return confDetail[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking particular track from database.
        /// </summary>
        public static Track GetTrack(int trackId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from track in db.Tracks
                                    where track.TrackId == trackId
                                    select track;
                    Track selectedTrack = trackInDB.FirstOrDefault();
                    return selectedTrack;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking particular track from database.
        /// </summary>
        public static Track GetTrack(int trackId, WvConferenceContext db)
        {
            try
            {
               
                    var trackInDB = from track in db.Tracks
                                    where track.TrackId == trackId
                                    select track;
                    Track selectedTrack = trackInDB.FirstOrDefault();
                    return selectedTrack;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking particular attendee details from database.
        /// </summary>
        public static Attendee GetAttendee(int attendeeId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var attendeeInDB = from attendee in db.Attendees
                                       where attendee.AttendeeId == attendeeId
                                       select attendee;
                    Attendee selectedAttendee = attendeeInDB.FirstOrDefault();
                    return selectedAttendee;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking speaker details.
        /// </summary>
        public static Speaker GetSpeaker(int speakerId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from speaker in db.Speakers
                                      where speaker.SpeakerId == speakerId
                                      select speaker;
                    Speaker selectedspeaker = speakerInDB.FirstOrDefault();
                    return selectedspeaker;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking speaker details.
        /// </summary>
        public static Speaker GetSpeaker(int speakerId, WvConferenceContext db)
        {
            try
            {
                var speakerInDB = from speaker in db.Speakers
                                  where speaker.SpeakerId == speakerId
                                  select speaker;
                Speaker selectedspeaker = speakerInDB.FirstOrDefault();
                return selectedspeaker;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking speakers of a conference.
        /// </summary>
        public static ObservableCollection<Speaker> GetConferenceSpeaker(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = (from speaker in db.Speakers
                                       join speakerConf in db.Conference_Speakers on speaker.SpeakerId equals speakerConf.Speaker_Id
                                       where speakerConf.Conference_Id == conferenceId
                                       select speaker);
                    ObservableCollection<Speaker> confDetail = new ObservableCollection<Speaker>();
                    foreach (Speaker speaker in speakerInDB)
                    {
                        if (!confDetail.Contains(speaker))
                        {
                            confDetail.Add(speaker);
                        }
                    }

                    return confDetail;
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking about details of a conference.
        /// </summary>
        public static About GetConferenceAbout(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var aboutInDB = (from about in db.Abouts
                                     where about.About_ConfId == conferenceId
                                     select about);
                    return aboutInDB.FirstOrDefault();
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking messages details of a conference.
        /// </summary>
        public static ObservableCollection<Message> GetConferenceMessage(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = (from message in db.Messages
                                       where message.Message_ConfId == conferenceId
                                       select message);
                    ObservableCollection<Message> messageCollection = new ObservableCollection<Message>(messageInDB);
                    return messageCollection;
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking messages details of a conference.
        /// </summary>
        public static List<int> GetConferenceReadMessage(string conferenceId) 
        {
            try
            {
                List<int> messageIdList = new List<int>();
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = (from message in db.Messages
                                       where message.Message_ConfId == conferenceId && message.Read == true
                                       select message);
                    foreach(Message msg in messageInDB)
                    {
                        messageIdList.Add(msg.MessageId);
                    }
                    return messageIdList;
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking messages details of a conference.
        /// </summary>
        public static List<int> GetConferenceMessageIds(string conferenceId) 
        {
            try
            {
                List<int> messageIdList = new List<int>();
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = (from message in db.Messages
                                       where message.Message_ConfId == conferenceId
                                       select message);
                    foreach (Message msg in messageInDB)
                    {
                        messageIdList.Add(msg.MessageId);
                    }
                    return messageIdList;
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking info details of a conference.
        /// </summary>
        public static ObservableCollection<RelatedInformation> GetConferenceInfo(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = (from info in db.RelatedInformations
                                       where info.Info_ConfId == conferenceId
                                       select info);
                    ObservableCollection<RelatedInformation> infoCollection = new ObservableCollection<RelatedInformation>(messageInDB);
                    return infoCollection;
                }
            }

            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser details of a conference.
        /// </summary>
        public static ObservableCollection<Sponsor> GetConferenceSponser(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponser in db.Sponsors
                                      where sponser.Sponsor_ConfId == conferenceId
                                      select sponser;
                    ObservableCollection<Sponsor> sponserDetail = new ObservableCollection<Sponsor>();
                    foreach (Sponsor sponsor in sponserInDB)
                    {
                        if (!sponserDetail.Contains(sponsor))
                        {
                            sponserDetail.Add(sponsor);
                        }
                    }
                    return sponserDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser details in different levels.
        /// </summary>
        public static ObservableCollection<Sponsor> GetConferenceSponser(string conferenceId, int levelId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponser in db.Sponsors
                                      join sponserLevel in db.Sponsor_SponsorLevels on sponser.SponsorId equals sponserLevel.Sponsor_Id
                                      where sponser.Sponsor_ConfId == conferenceId && sponserLevel.SponsorLevel_Id == levelId
                                      select sponser;
                    ObservableCollection<Sponsor> sponserDetail = new ObservableCollection<Sponsor>(sponserInDB);
                    foreach (Sponsor sponsor in sponserInDB)
                    {
                        if (!sponserDetail.Contains(sponsor))
                        {
                            sponserDetail.Add(sponsor);
                        }
                    }
                    return sponserDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser details.
        /// </summary>
        public static Sponsor GetSponser(int sponserId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponser in db.Sponsors
                                      where sponser.SponsorId == sponserId
                                      select sponser;
                    Sponsor selectedSponsor = sponserInDB.FirstOrDefault();
                    return selectedSponsor;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser details.
        /// </summary>
        public static string GetSponserLevelName(int sponserId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponser in db.Sponsors
                                      join spo_spoLevel in db.Sponsor_SponsorLevels on sponser.SponsorId equals spo_spoLevel.Sponsor_Id
                                      join sponsorLevel in db.SponsorLevels on spo_spoLevel.SponsorLevel_Id equals sponsorLevel.SponsorlevelId
                                      where sponser.SponsorId == sponserId
                                      select sponsorLevel.SponsorLevel_Name;
                    return sponserInDB.FirstOrDefault();;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser details.
        /// </summary>
        public static Sponsor GetSponser(int sponserId, WvConferenceContext db)
        {
            try
            {                
                    var sponserInDB = from sponser in db.Sponsors
                                      where sponser.SponsorId == sponserId
                                      select sponser;
                    Sponsor selectedSponsor = sponserInDB.FirstOrDefault();
                    return selectedSponsor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking message details.
        /// </summary>
        public static Message GetMessage(int messageId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = from message in db.Messages
                                      where message.MessageId == messageId
                                      select message;
                    Message selectedMessage = messageInDB.FirstOrDefault();
                    return selectedMessage;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking message details.
        /// </summary>
        public static Message GetMessage(int messageId,WvConferenceContext db )
        {
            try
            {
                
                var messageInDB = from message in db.Messages
                                    where message.MessageId == messageId
                                    select message;
                Message selectedMessage = messageInDB.FirstOrDefault();
                return selectedMessage;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking unread message count.
        /// </summary>
        public static int GetUnReadMessageCount(string confId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = from message in db.Messages
                                      where message.Message_ConfId == confId && message.Read == false
                                      select message;
                    List<Message> selectedMessages = new List<Message>(messageInDB);
                    return (selectedMessages != null) ? selectedMessages.Count : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking unread message count.
        /// </summary>
        public static int GetMessageCount(string confId) 
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = from message in db.Messages
                                      where message.Message_ConfId == confId
                                      select message;
                    List<Message> selectedMessages = new List<Message>(messageInDB);
                    return (selectedMessages != null) ? selectedMessages.Count : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking info details.
        /// </summary>
        public static RelatedInformation GetInfo(int infoId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var infoInDB = from info in db.RelatedInformations
                                   where info.RelatedInformationsId == infoId
                                   select info;
                    RelatedInformation selectedInfo = infoInDB.FirstOrDefault();
                    return selectedInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser level details.
        /// </summary>
        public static SponsorLevel GetSponserLevel(int sponserLevelId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserLevelInDB = from sponserLevel in db.SponsorLevels
                                           where sponserLevel.SponsorlevelId == sponserLevelId
                                           select sponserLevel;
                    SponsorLevel selectedSponserLevel = sponserLevelInDB.FirstOrDefault();
                    return selectedSponserLevel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking sponser level details.
        /// </summary>
        public static SponsorLevel GetSponserLevel(int sponserLevelId, WvConferenceContext db)
        {
            try
            { 
                var sponserLevelInDB = from sponserLevel in db.SponsorLevels
                                           where sponserLevel.SponsorlevelId == sponserLevelId
                                           select sponserLevel;
                SponsorLevel selectedSponserLevel = sponserLevelInDB.FirstOrDefault();
                return selectedSponserLevel;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking List of sessions from conferences.
        /// </summary>
        public static ObservableCollection<Session> GetConferenceSessions(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      where session.Session_ConfId == conferenceId
                                      select session;
                    ObservableCollection<Session> sessionList = new ObservableCollection<Session>(sessionInDB);
                    return sessionList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking session details.
        /// </summary>
        public static Session GetSessionDetails(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      where session.SessionId == sessionId
                                      select session;
                    Session sessionItem = (Session)sessionInDB.FirstOrDefault();
                    return sessionItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking Session_Track details.
        /// </summary>
        public static Session_Track GetSession_TrackDetails(int sessionId, int trackId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionTrackInDB = from session_Track in db.Session_Tracks
                                           where session_Track.Session_Id == sessionId && session_Track.Track_Id == trackId
                                           select session_Track;
                    Session_Track sessionItem = (Session_Track)sessionTrackInDB.FirstOrDefault();
                    return sessionItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking Speaker_Sessions details.
        /// </summary>
        public static Speaker_Session GetSpeaker_SessionDetails(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerSessionInDB = from session_Speaker in db.Speaker_Sessions
                                             where session_Speaker.Spkr_SessionId == sessionId
                                             select session_Speaker;
                    Speaker_Session sessionItem = (Speaker_Session)speakerSessionInDB.FirstOrDefault();
                    return sessionItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking session speaker details.
        /// </summary>
        public static Speaker GetSessionSpeaker(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from speaker in db.Speakers
                                      join spkrsession in db.Speaker_Sessions on speaker.SpeakerId equals spkrsession.Spkr_Id
                                      where spkrsession.Spkr_SessionId == sessionId
                                      select speaker;
                    Speaker selectedspeaker = speakerInDB.FirstOrDefault();
                    return selectedspeaker;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking speaker sessions details.
        /// </summary>
        public static ObservableCollection<Session> GetSpeakerSessions(string conferenceId, int speakerId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      join spkrsession in db.Speaker_Sessions on session.SessionId equals spkrsession.Spkr_SessionId
                                      join speaker in db.Speakers on spkrsession.Spkr_Id equals speaker.SpeakerId
                                      where session.Session_ConfId == conferenceId && speaker.SpeakerId == speakerId
                                      select session;
                    ObservableCollection<Session> sessionList = new ObservableCollection<Session>(sessionInDB);
                    return sessionList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking List of attendees for a session.
        /// </summary>
        public static ObservableCollection<Attendee> GetSessionAttendees(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from attendee in db.Attendees
                                      where attendee.Attendee_SessionId == sessionId
                                      select attendee;
                    ObservableCollection<Attendee> attendeesList = new ObservableCollection<Attendee>(sessionInDB);
                    return attendeesList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking List of conferences from database.
        /// </summary>
        public static ObservableCollection<Conference> GetConferenceList()
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conferenceInDB = from conference in db.Conferences
                                         where conference.IsAdded == true
                                         select conference;
                    ObservableCollection<Conference> conferenceList = new ObservableCollection<Conference>(conferenceInDB);
                    return conferenceList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find a conference.
        /// </summary>
        /// <param name="_DeleteConference">Conference to delete</param>
        public static Conference FindConference(string conferenceId)
        {
            try
            {
                Conference selectedConference = null;
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conferenceInDB = from conference in db.Conferences
                                         where conference.ConferenceId == conferenceId
                                         select conference;
                    if (conferenceInDB != null)
                    {
                        selectedConference = conferenceInDB.FirstOrDefault();
                    }
                    return selectedConference;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking conference tabs.
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <returns></returns>
        public static List<Conference_Tab> GetConferenceTabList(string conferenceId)
        {
            try
            {
                List<Conference_Tab> confrnc_TabList = null;
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conferenceInDB = from conference_Tab in db.Conference_Tabs
                                         where conference_Tab.Conference_Id == conferenceId
                                         select conference_Tab;
                    confrnc_TabList = conferenceInDB.ToList();
                    return confrnc_TabList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Taking Conference levels.
        /// </summary>
        /// <returns></returns>
        public static List<SponsorLevel> GetSponserLevels()
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserLevelsInDB = from sponserLevel in db.SponsorLevels
                                            select sponserLevel;
                    List<SponsorLevel> selectedSponserLevels = sponserLevelsInDB.ToList();
                    return selectedSponserLevels;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Deletion

        /// <summary>
        /// Delete tracks in sessions.
        /// </summary>
        public static void DeleteSessionTracks(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from session_Track in db.Session_Tracks
                                    where session_Track.Session_Id == sessionId
                                    select session_Track;
                    List<Session_Track> selectedTrack = new List<Session_Track>(trackInDB);
                    db.Session_Tracks.DeleteAllOnSubmit(selectedTrack);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete tracks in sessions.
        /// </summary>
        public static void DeleteSessionTracks(int sessionId, WvConferenceContext db)
        {
            try
            {

                var trackInDB = from session_Track in db.Session_Tracks
                                where session_Track.Session_Id == sessionId
                                select session_Track;
                List<Session_Track> selectedTrack = new List<Session_Track>(trackInDB);
                db.Session_Tracks.DeleteAllOnSubmit(selectedTrack);                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete tracks in session.
        /// </summary>
        public static void DeleteSessionTrack(int trackId) 
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from session_Track in db.Session_Tracks
                                    where session_Track.Track_Id == trackId
                                    select session_Track;
                    List<Session_Track> selectedTrack = new List<Session_Track>(trackInDB);
                    db.Session_Tracks.DeleteAllOnSubmit(selectedTrack);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete tracks in session.
        /// </summary>
        public static void DeleteSessionTrack(int trackId,WvConferenceContext db)
        {
            try
            {
                
                    var trackInDB = from session_Track in db.Session_Tracks
                                    where session_Track.Track_Id == trackId
                                    select session_Track;
                    List<Session_Track> selectedTrack = new List<Session_Track>(trackInDB);
                    db.Session_Tracks.DeleteAllOnSubmit(selectedTrack);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Delete traks of conference.
        /// </summary>
        public static void DeleteConferenceTracks(string confId,int trackId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from track in db.Tracks
                                    where track.Track_ConfId == confId && track.TrackId == trackId
                                    select track;
                    List<Track> selectedTrack = new List<Track>(trackInDB);
                    db.Tracks.DeleteAllOnSubmit(selectedTrack);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete traks of conference.
        /// </summary>
        public static void DeleteConferenceTracks(string confId, int trackId, WvConferenceContext db)
        {
            try
            {
               
                var trackInDB = from track in db.Tracks
                                where track.Track_ConfId == confId && track.TrackId == trackId
                                select track;
                List<Track> selectedTrack = new List<Track>(trackInDB);
                db.Tracks.DeleteAllOnSubmit(selectedTrack);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete traks of conference.
        /// </summary>
        public static void DeleteConferenceTracks(string confId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var trackInDB = from track in db.Tracks
                                    where track.Track_ConfId == confId 
                                    select track;
                    List<Track> selectedTrack = new List<Track>(trackInDB);
                    db.Tracks.DeleteAllOnSubmit(selectedTrack);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete traks of conference.
        /// </summary>
        public static void DeleteConferenceTracks(string confId,WvConferenceContext db)
        {
            try
            {
                var trackInDB = from track in db.Tracks
                                where track.Track_ConfId == confId
                                select track;
                List<Track> selectedTrack = new List<Track>(trackInDB);
                db.Tracks.DeleteAllOnSubmit(selectedTrack);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete sponser and sponser relations.
        /// </summary>
        public static void DeleteSponserSponserLevelRelation(int sponserId, string confId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserLevelInDB = from sponserLevel in db.Sponsor_SponsorLevels
                                           join sponsor in db.Sponsors on sponserLevel.Sponsor_Id equals sponsor.SponsorId
                                           where sponserLevel.Sponsor_Id == sponserId && sponsor.Sponsor_ConfId == confId
                                           select sponserLevel;
                    List<Sponsor_SponsorLevel> selectedLevels = new List<Sponsor_SponsorLevel>(sponserLevelInDB);
                    db.Sponsor_SponsorLevels.DeleteAllOnSubmit(selectedLevels);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete sponser and sponser relations.
        /// </summary>
        public static void DeleteSponserSponserLevelRelation(int sponserId, string confId,WvConferenceContext db)
        {
            try
            {
                var sponserLevelInDB = from sponserLevel in db.Sponsor_SponsorLevels
                                            join sponsor in db.Sponsors on sponserLevel.Sponsor_Id equals sponsor.SponsorId
                                            where sponserLevel.Sponsor_Id == sponserId && sponsor.Sponsor_ConfId == confId
                                            select sponserLevel;
                List<Sponsor_SponsorLevel> selectedLevels = new List<Sponsor_SponsorLevel>(sponserLevelInDB);
                db.Sponsor_SponsorLevels.DeleteAllOnSubmit(selectedLevels);                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference_Speaker relations.
        /// </summary>
        public static void DeleteSpeakerConferenceRelation(int speakerId, string confId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from speakerrelation in db.Conference_Speakers
                                      where speakerrelation.Speaker_Id == speakerId && speakerrelation.Conference_Id == confId
                                      select speakerrelation;
                    List<Conference_Speaker> selectedRelations = new List<Conference_Speaker>(speakerInDB);
                    db.Conference_Speakers.DeleteAllOnSubmit(selectedRelations);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference_Speaker relations.
        /// </summary>
        public static void DeleteSpeakerConferenceRelation(int speakerId, string confId,WvConferenceContext db)
        {
            try
            {
                var speakerInDB = from speakerrelation in db.Conference_Speakers
                                    where speakerrelation.Speaker_Id == speakerId && speakerrelation.Conference_Id == confId
                                    select speakerrelation;
                List<Conference_Speaker> selectedRelations = new List<Conference_Speaker>(speakerInDB);
                db.Conference_Speakers.DeleteAllOnSubmit(selectedRelations);
                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        /// <summary>
        /// Deleting Conference_Speaker relations.
        /// </summary>
        public static void DeleteSpeakerConferenceRelation(string confId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from speakerrelation in db.Conference_Speakers
                                      where speakerrelation.Conference_Id == confId
                                      select speakerrelation;
                    List<Conference_Speaker> selectedRelations = new List<Conference_Speaker>(speakerInDB);
                    db.Conference_Speakers.DeleteAllOnSubmit(selectedRelations);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Deleting Conference_Speaker relations.
        /// </summary>
        public static void DeleteSpeakerConferenceRelation(string confId,WvConferenceContext db)
        {
            try
            {
                var speakerInDB = from speakerrelation in db.Conference_Speakers
                                    where speakerrelation.Conference_Id == confId
                                    select speakerrelation;
                List<Conference_Speaker> selectedRelations = new List<Conference_Speaker>(speakerInDB);
                db.Conference_Speakers.DeleteAllOnSubmit(selectedRelations);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete session from database.
        /// </summary>
        public static void DeleteSession(int sessionId)
        {
            try
            {
                DbHelper.DeleteSessionAttendee(sessionId);
                DbHelper.DeleteSessionSpeaker(sessionId);
                DbHelper.DeleteSessionTracks(sessionId);
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      where session.SessionId == sessionId
                                      select session;
                    List<Session> selectedSessions = new List<Session>(sessionInDB);
                    db.Sessions.DeleteAllOnSubmit(selectedSessions);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete session from database.
        /// </summary>
        public static void DeleteSession(int sessionId, WvConferenceContext db)
        {
            try
            {
               
                DbHelper.DeleteSessionAttendee(sessionId,db);
                DbHelper.DeleteSessionSpeaker(sessionId,db);
                DbHelper.DeleteSessionTracks(sessionId,db);
                var sessionInDB = from session in db.Sessions
                                    where session.SessionId == sessionId
                                    select session;
                List<Session> selectedSessions = new List<Session>(sessionInDB);
                db.Sessions.DeleteAllOnSubmit(selectedSessions);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete session Speaker relations.
        /// </summary>
        public static void DeleteSessionSpeaker(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from speaker_Session in db.Speaker_Sessions
                                      where speaker_Session.Spkr_SessionId == sessionId
                                      select speaker_Session;
                    List<Speaker_Session> selectedTrack = new List<Speaker_Session>(speakerInDB);
                    db.Speaker_Sessions.DeleteAllOnSubmit(selectedTrack);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete session Speaker relations.
        /// </summary>
        public static void DeleteSessionSpeaker(int sessionId,WvConferenceContext db)
        {
            try
            {                
                var speakerInDB = from speaker_Session in db.Speaker_Sessions
                                    where speaker_Session.Spkr_SessionId == sessionId
                                    select speaker_Session;
                List<Speaker_Session> selectedTrack = new List<Speaker_Session>(speakerInDB);
                db.Speaker_Sessions.DeleteAllOnSubmit(selectedTrack);               
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete Session Attendees.
        /// </summary>
        public static void DeleteSessionAttendee(int sessionId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var speakerInDB = from attendees in db.Attendees
                                      where attendees.Attendee_SessionId == sessionId
                                      select attendees;
                    List<Attendee> selectedAttendee = new List<Attendee>(speakerInDB);
                    db.Attendees.DeleteAllOnSubmit(selectedAttendee);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Session Attendees.
        /// </summary>
        public static void DeleteSessionAttendee(int sessionId,WvConferenceContext db)
        {
            try
            {
                var speakerInDB = from attendees in db.Attendees
                                      where attendees.Attendee_SessionId == sessionId
                                      select attendees;
                List<Attendee> selectedAttendee = new List<Attendee>(speakerInDB);
                db.Attendees.DeleteAllOnSubmit(selectedAttendee);
                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete a conference.
        /// </summary>
        /// <param name="_DeleteConference">Conference to delete</param>
        public static void DeleteConference(string conferenceId)
        {
            try
            {
                Conference confrnceToDelete = null;
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conferenceInDB = from conference in db.Conferences
                                         where conference.ConferenceId == conferenceId
                                         select conference;
                    if (conferenceInDB != null)
                    {
                        confrnceToDelete = conferenceInDB.FirstOrDefault();
                        ObservableCollection<Session> sessions = DbHelper.GetConferenceSessions(conferenceId);
                        foreach (Session session in sessions)
                        {
                            DbHelper.DeleteSession(session.SessionId,db);
                        }
                        ObservableCollection<Sponsor> sponsers = GetConferenceSponser(conferenceId);
                        foreach (Sponsor sponser in sponsers)
                        {
                            DbHelper.DeleteSponserSponserLevelRelation(sponser.SponsorId,db);
                        }
                        db.SubmitChanges();
                        DeleteConferenceSponsers(conferenceId,db);
                        DeleteConferenceAbout(conferenceId,db);
                        DeleteConferenceTracks(conferenceId,db);
                        DeleteConferenceMessages(conferenceId,db);
                        DeleteConferenceInfo(conferenceId,db);
                        DeleteConferenceTabList(confrnceToDelete.ConferenceId,db);
                        DeleteSpeakerConferenceRelation(conferenceId,db);
                        db.Conferences.DeleteOnSubmit(confrnceToDelete);
                        db.SubmitChanges();
                    }
                    else
                    {
                        new Exception("Conference not in database");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Tab Relationship for a particular conference.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceTabList(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var conferenceInDB = from conference_Tab in db.Conference_Tabs
                                         where conference_Tab.Conference_Id == conferenceId
                                         select conference_Tab;
                    foreach (Conference_Tab objConference_Tab in conferenceInDB)
                    {
                        db.Conference_Tabs.DeleteOnSubmit(objConference_Tab);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Tab Relationship for a particular conference.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceTabList(string conferenceId,WvConferenceContext db)
        {
            try
            {
                    var conferenceInDB = from conference_Tab in db.Conference_Tabs
                            where conference_Tab.Conference_Id == conferenceId
                            select conference_Tab;
                    foreach (Conference_Tab objConference_Tab in conferenceInDB)
                    {
                        db.Conference_Tabs.DeleteOnSubmit(objConference_Tab);                        
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponsors of a particular conference.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceSponsers(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponser in db.Sponsors
                                      where sponser.Sponsor_ConfId == conferenceId
                                      select sponser;
                    foreach (Sponsor sponser in sponserInDB)
                    {
                        db.Sponsors.DeleteOnSubmit(sponser);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponsors of a particular conference.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceSponsers(string conferenceId,WvConferenceContext db)
        {
            try
            {
                
                var sponserInDB = from sponser in db.Sponsors
                                    where sponser.Sponsor_ConfId == conferenceId
                                    select sponser;
                foreach (Sponsor sponser in sponserInDB)
                {
                    db.Sponsors.DeleteOnSubmit(sponser);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Messages.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceMessages(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var messageInDB = from message in db.Messages
                                      where message.Message_ConfId == conferenceId
                                      select message;
                    foreach (Message message in messageInDB)
                    {
                        db.Messages.DeleteOnSubmit(message);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Messages.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceMessages(string conferenceId,WvConferenceContext db)
        {
            try
            {
                var messageInDB = from message in db.Messages
                                    where message.Message_ConfId == conferenceId
                                    select message;
                foreach (Message message in messageInDB)
                {
                    db.Messages.DeleteOnSubmit(message);                        
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Informations.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceInfo(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var infoInDB = from info in db.RelatedInformations
                                   where info.Info_ConfId == conferenceId
                                   select info;
                    foreach (RelatedInformation info in infoInDB)
                    {
                        db.RelatedInformations.DeleteOnSubmit(info);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference Informations.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceInfo(string conferenceId, WvConferenceContext db)
        {
            try
            {
                
                    var infoInDB = from info in db.RelatedInformations
                                   where info.Info_ConfId == conferenceId
                                   select info;
                    foreach (RelatedInformation info in infoInDB)
                    {
                        db.RelatedInformations.DeleteOnSubmit(info);
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference About Details.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceAbout(string conferenceId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var aboutInDB = from about in db.Abouts
                                    where about.About_ConfId == conferenceId
                                    select about;
                    foreach (About about in aboutInDB)
                    {
                        db.Abouts.DeleteOnSubmit(about);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Conference About Details.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteConferenceAbout(string conferenceId,WvConferenceContext db)
        {
            try
            {
                var aboutInDB = from about in db.Abouts
                                    where about.About_ConfId == conferenceId
                                    select about;
                foreach (About about in aboutInDB)
                {
                    db.Abouts.DeleteOnSubmit(about);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponser level relationship.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteSponserSponserLevelRelation(int sponserId, int levelId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponserlevels in db.Sponsor_SponsorLevels
                                      where sponserlevels.Sponsor_Id == sponserId && sponserlevels.SponsorLevel_Id == levelId
                                      select sponserlevels;
                    foreach (Sponsor_SponsorLevel sponser in sponserInDB)
                    {
                        db.Sponsor_SponsorLevels.DeleteOnSubmit(sponser);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponser level relationship.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteSponserSponserLevelRelation(int sponserId, int levelId,WvConferenceContext db)
        {
            try
            {
               
                var sponserInDB = from sponserlevels in db.Sponsor_SponsorLevels
                                    where sponserlevels.Sponsor_Id == sponserId && sponserlevels.SponsorLevel_Id == levelId
                                    select sponserlevels;
                foreach (Sponsor_SponsorLevel sponser in sponserInDB)
                {
                    db.Sponsor_SponsorLevels.DeleteOnSubmit(sponser);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponser level relationship.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteSponserSponserLevelRelation(int sponserId)
        {
            try
            {
                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sponserInDB = from sponserlevels in db.Sponsor_SponsorLevels
                                      where sponserlevels.Sponsor_Id == sponserId 
                                      select sponserlevels;
                    foreach (Sponsor_SponsorLevel sponser in sponserInDB)
                    {
                        db.Sponsor_SponsorLevels.DeleteOnSubmit(sponser);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleting Sponser level relationship.
        /// </summary>
        /// <param name="conferenceId"></param>
        public static void DeleteSponserSponserLevelRelation(int sponserId,WvConferenceContext db)
        {
            try
            {
                
                var sponserInDB = from sponserlevels in db.Sponsor_SponsorLevels
                                    where sponserlevels.Sponsor_Id == sponserId
                                    select sponserlevels;
                foreach (Sponsor_SponsorLevel sponser in sponserInDB)
                {
                    db.Sponsor_SponsorLevels.DeleteOnSubmit(sponser);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Updation

        /// <summary>
        /// update session.
        /// </summary>
        public static void UpdateSession(int sessionId, bool isMine)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      where session.SessionId == sessionId
                                      select session;
                    Session selectedSession = (Session)sessionInDB.FirstOrDefault();
                    selectedSession.Mine = isMine;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update message Status.
        /// </summary>
        public static void UpdateMessageStatus(int messageId, string confId, bool isOpened)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from message in db.Messages
                                      where message.MessageId == messageId && message.Message_ConfId == confId
                                      select message;
                    Message selectedSession = (Message)sessionInDB.FirstOrDefault();
                    selectedSession.Read = isOpened;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Conference Versin.
        /// </summary>
        public static void UpdateConferenceVersion(string conferenceId, int version, string tabId)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from conf in db.Conference_Tabs
                                      where conf.Conference_Id == conferenceId && conf.Tab_Id == tabId
                                      select conf;
                    Conference_Tab selectedSession = sessionInDB.FirstOrDefault();
                    selectedSession.Version = version;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Conference Order.
        /// </summary>
        public static void UpdateConferenceOrder(string conferenceId, int order, string tabId) 
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from conf in db.Conference_Tabs
                                      where conf.Conference_Id == conferenceId && conf.Tab_Id == tabId
                                      select conf;
                    Conference_Tab selectedSession = sessionInDB.FirstOrDefault();
                    selectedSession.Order = order;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Tab Visibility.
        /// </summary>
        public static void UpdateConferenceTabVisibility(string conferenceId, bool tabVisibility, string tabId)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from conf in db.Conference_Tabs
                                      where conf.Conference_Id == conferenceId && conf.Tab_Id == tabId
                                      select conf;
                    Conference_Tab selectedSession = sessionInDB.FirstOrDefault();
                    selectedSession.IsVisible = tabVisibility;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Conference.
        /// </summary>
        public static void UpdateConference(string conferenceId, List<ConferenceDetails> conferDetails)
        {
            try
            {
                foreach (ConferenceDetails confrDetails in conferDetails)
                {

                    using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                    {
                        var sessionInDB = from conf in db.Conferences
                                          where conf.ConferenceId == conferenceId
                                          select conf;
                        Conference selectedConference = sessionInDB.FirstOrDefault();
                        selectedConference.Description = confrDetails.TimeZoneId;
                        selectedConference.RequiresPin = confrDetails.RequiresPin;
                        selectedConference.AppLocation = confrDetails.ApplicationLocationName;
                        selectedConference.CenterId = confrDetails.ConferenceCenterId;
                        selectedConference.ContactName = confrDetails.ContactName;
                        selectedConference.ContactPhone = confrDetails.ContactPhone;
                        selectedConference.ContactTitle = confrDetails.ContactTitle;
                        selectedConference.EndDate = TimeZoneInfo.ConvertTime(confrDetails.EndDate, TimeZoneInfo.Utc);
                        selectedConference.StartDate = TimeZoneInfo.ConvertTime(confrDetails.StartDate, TimeZoneInfo.Utc);
                        selectedConference.TwtrHashTag = confrDetails.TwitterHashTag;
                        selectedConference.WebSite = confrDetails.Website;
                        selectedConference.TimeZone = confrDetails.TimeZoneId;
                        selectedConference.Name = confrDetails.Name;
                        selectedConference.Location = confrDetails.LocationName;
                        selectedConference.LocationAddress1 = confrDetails.LocationAddress1;
                        selectedConference.LocationAddress2 = confrDetails.LocationAddress2;
                        selectedConference.LocationCity = confrDetails.LocationCity;
                        selectedConference.LocationState = confrDetails.LocationState;
                        selectedConference.LocationZip = confrDetails.LocationZip;
                        selectedConference.OrganizationId = confrDetails.OrganizationId;
                        selectedConference.ImageUrl = confrDetails.ConferenceImageUrl;
                        selectedConference.IsCurrent = confrDetails.IsCurrent;
                        db.SubmitChanges();                        
                    }
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Tab Name.
        /// </summary>
        public static void UpdateTabName(string conferenceId, string tabName, string tabId)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var tabInDB = from tab in db.TabMasters
                                  where tab.TabId == tabId
                                  select tab;
                    TabMaster selectedTab = tabInDB.FirstOrDefault();
                    selectedTab.Tab_Name = tabName;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// update session checkins.
        /// </summary>
        public static void SessionCheckin(int sessionId, bool isChecked)
        {
            try
            {

                using (WvConferenceContext db = new WvConferenceContext(GetConnectionString()))
                {
                    var sessionInDB = from session in db.Sessions
                                      where session.SessionId == sessionId
                                      select session;
                    Session selectedSession = (Session)sessionInDB.FirstOrDefault();
                    selectedSession.IsChecked = isChecked;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

    }
}
