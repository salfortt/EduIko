using Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Common
{
    public   class MissionOperations
    {
        //private NewsDAL() { }
        private static MissionOperations Instance;
        public static MissionOperations GetInstance()
        {
            if (Instance == null)
                Instance = new MissionOperations();

            return Instance;
        }

        public   Mission  CreateMission(ObjectId createdUser,bool isMain,string FK_MainMissionID, string FK_ReletionJobID, string title, string description,
            string note,DateTime startDate, DateTime endDate,List<string> filesPath,
            List<ObjectId> appointedList,
            UserTypeEnum userTypeEnum,
            AppointmentType appointmentType,
            MissionType MissionType,
            MissionCreateType MissionCreateType,
            MissionJobPeriodType MissionJobPeriodType,
            MissionStatus MissionStatus
            )
        {
            Mission Mission = new Mission();
            ObjectId fK_MainMissionID=ObjectId.Parse("000000000000000000000000");

            if (!string.IsNullOrEmpty(FK_MainMissionID) && "000000000000000000000000" != FK_MainMissionID)
                fK_MainMissionID =ObjectId.Parse( FK_MainMissionID);

            if (!string.IsNullOrEmpty(FK_ReletionJobID) && "000000000000000000000000" != FK_ReletionJobID)  
                Mission.FK_ReletionJobID = ObjectId.Parse(FK_ReletionJobID);
           
            Mission.id= ObjectId.GenerateNewId();
            Mission.FK_InitiatorID = createdUser;
            Mission.IsMainMisson = isMain;
           
            Mission.CreatedDate = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);

            if (!isMain)//ana görev değilse
                Mission.FK_MainID = fK_MainMissionID;


            Mission.MissionStatus = MissionStatus;
            Mission.Title = title;
            Mission.Description = description;

            #region not ekleme
            if (!string.IsNullOrEmpty(note))
            {

            
            if (Mission.CheckNotes == null)
                Mission.CheckNotes = new List<CheckNote>();

            CheckNote cn = new CheckNote();

            cn.CreatedDate = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
            if(filesPath != null && filesPath.Count > 0) 
            { 
            cn.FilesPath = new List<string>();
            cn.FilesPath = filesPath;
            }
            cn.FK_UserID = createdUser;
            cn.Note = note;

            Mission.CheckNotes.Add(cn);
            }
            #endregion

            #region Mission properties ekleme
            MissionProperties MissionP = new MissionProperties();

            MissionP.AppointedList = new List<ObjectId>();
            MissionP.AppointedList = appointedList;
            MissionP.UserTypeEnum = userTypeEnum;
            MissionP.AppointmentType = appointmentType;
            MissionP.MissionCreateType = MissionCreateType;
            MissionP.MissionJobPeriod = MissionJobPeriodType;
            MissionP.MissionType = MissionType;
            MissionP.StartDate = startDate;
            MissionP.EndDate = endDate;
                

            Mission.MissionProperties = MissionP;
            #endregion


            //public MissionProperties MissionProperties { get; set; }
            //public List<MissionSequence> MissionSequence { get; set; }


            return Mission;




        }


        public MissionTracking CreateMissionTracking(Mission Mission)
        {
            MissionTracking Missiont = new MissionTracking();

            Missiont.id = ObjectId.GenerateNewId();
            Missiont.StartDate = Mission.MissionProperties.StartDate;
            Missiont.EndDate = Mission.MissionProperties.EndDate;
            Missiont.Title = Mission.Title;
            Missiont.AppointedList = Mission.MissionProperties.AppointedList;
            Missiont.FK_ReletionJobID = Mission.FK_ReletionJobID;
            Missiont.MissionStatus = Mission.MissionStatus;
            Missiont.MissionType = Mission.MissionProperties.MissionType;
            Missiont.FK_InitiatorID = Mission.FK_InitiatorID;
            Missiont.FK_RLPID = Mission.id;

            return Missiont;


        }


    }
}
