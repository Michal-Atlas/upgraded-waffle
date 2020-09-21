using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meetings
{
    public class MeetingClass
    {
        public class Meeting
        {
            public int StartTime { get; set; }

            public int EndTime { get; set; }

            public Meeting(int startTime, int endTime)
            {
                // Number of 30 min blocks past 9:00 am
                StartTime = startTime;
                EndTime = endTime;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                if (ReferenceEquals(obj, this))
                {
                    return true;
                }

                var meeting = (Meeting)obj;
                return StartTime == meeting.StartTime && EndTime == meeting.EndTime;
            }

            public override int GetHashCode()
            {
                var result = 17;
                result = result * 31 + StartTime;
                result = result * 31 + EndTime;
                return result;
            }

            public override string ToString()
            {
                return $"({StartTime}, {EndTime})";
            }
        }

        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Implement me
            int max = -1;
            for (int i = 0; i < meetings.Count; i++){
                if (meetings[i].EndTime > max){
                    max = meetings[i].EndTime;
                }
            }

            bool[] mask = new bool[max+1];

            foreach (var meet in meetings)
            {
                for (int i = meet.StartTime; i < meet.EndTime; i++){
                    mask[i] = true;
                }
            }

            bool started = false;
            int start = -1;
            var output = new List<Meeting>();
            for (int i = 0; i < mask.Length; i++)
            {
                if (started && mask[i]){continue;}

                if (!started && mask[i])
                {
                    start = i;
                    started = true;
                }
                else if (started && !mask[i])
                {
                    output.Add(new Meeting(start, i));
                    started = false;
                }
            }
            if( started){output.Add(new Meeting(start, mask.Length));}    

	        return output;
        }
    }
}