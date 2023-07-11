using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WinSBSchool.Forms
{
    public class ItemInfo
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public string Text;
        public int A;
        public int R;
        public int G;
        public int B;
        HatchStyle pattern;
        Color patternColor;

        public ItemInfo()
        { }

        public ItemInfo(DateTime startTime, DateTime endTime, string text, Color color)
        {
            StartTime = startTime;
            EndTime = endTime;
            Text = text;
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }

    public class ItemInfo_DTO
    {
        public string StartTime;
        public string EndTime;
        public string Text;
        public string A;
        public string R;
        public string G;
        public string B; 


        public ItemInfo_DTO()
        { }

        public ItemInfo_DTO(string startTime, string endTime, string text, string colorA, string colorR, string colorG, string colorB)
        {
            StartTime = startTime;
            EndTime = endTime;
            Text = text;
            A = colorA;
            R = colorR;
            G = colorG;
            B = colorB; 
        }
    }

    public class ItemInfo_DTO_XML
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public string Text;
        public int A;
        public int R;
        public int G;
        public int B;
        public string SubjectShortCode;
        public int RoomId;
        public string Recurrent;
        public string Activity;
        public string Venue;


        public ItemInfo_DTO_XML()
        { }

        public ItemInfo_DTO_XML(DateTime startTime, DateTime endTime, string text, int colorA, int colorR, int colorG, int colorB, string subjectshortcode, int roomid, string recurrent, string activity, string venue)
        {
            StartTime = startTime;
            EndTime = endTime;
            Text = text;
            A = colorA;
            R = colorR;
            G = colorG;
            B = colorB;
            SubjectShortCode = subjectshortcode;
            RoomId = roomid;
            Recurrent = recurrent;
            Activity = activity;
            Venue = venue;
        }
    }

}
