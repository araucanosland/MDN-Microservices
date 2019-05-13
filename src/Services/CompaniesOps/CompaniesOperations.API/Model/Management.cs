using System;
using System.Collections.Generic;
using CompaniesOperations.API.Infrastructure.Exceptions;
/// <summary>
/// Created By: @Charlie
/// Created At: 2019-04-25 04:04 GMT-4
/// </summary>
namespace CompaniesOperations.API.Model
{
    public class Management
    {
        /// <summary>
        /// Id of the Entity
        /// </summary>
        /// <value>Is the primary key in the database</value>
        public int Id { get; set; }
        public int LeadId { get; set; }
        /// <summary>
        /// Lead is the lead of the Managements
        /// </summary>
        /// <value></value>
        public Lead Lead { get; set; }
        /// <summary>
        /// Comments: the comments is the description field
        /// </summary>
        /// <value>Comments</value>
        public string Comments { get; set; }

        /// <summary>
        /// Stats: is the composed value of the parent stat and the child stat
        /// </summary>
        /// <value>Stats</value>
        public string Stats { get; set; }
        /// <summary>
        /// NextCommitment: is the next date of commitment to remember and agenda
        /// </summary>
        /// <value>NextCommitment</value>
        public DateTime? NextCommitment { get; set; }
        /// <summary>
        /// The user or Executive who issued the new management
        /// </summary>
        /// <value></value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// CreatedIn: Is the office on has been created the management 
        /// </summary>
        /// <value>CreatedIn</value>
        public int CreatedIn { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Contrsuctor sin parametros
        /// </summary>
        public Management(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="comments"></param>
        /// <param name="parentStat"></param>
        /// <param name="childStat"></param>
        /// <param name="nextCommitment"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdIn"></param>
        public Management(int leadId, string comments, string parentStat, string childStat, DateTime? nextCommitment, string createdBy, int createdIn)
        {
            LeadId = leadId;
            Comments = comments;
            NextCommitment = nextCommitment;
            CreatedBy = createdBy;
            CreatedIn = createdIn;
            CreatedAt = DateTime.Now;
            Stats = composeStats(parentStat, childStat);
        }

        public Management(string composedStats){
            Stats = composedStats;
        }

        public Management(int parentStat, int childStat)
        {
            Stats = composeStats(parentStat.ToString(), childStat.ToString());
        }

        private string composeStats(string parentStat, string childStat){
            return parentStat.PadLeft(3, '0') + childStat.PadLeft(3, '0');
        }

        public int getChildStatId()
        {
            if(string.IsNullOrEmpty(Stats)){
                throw new EmptyStatException("Stats field is Empty");
            }

            return Convert.ToInt32(Stats.Substring(2));
        }

        public int getParentStatId()
        {
            if (string.IsNullOrEmpty(Stats))
            {
                throw new EmptyStatException("Stats field is Empty");
            }

            return Convert.ToInt32(Stats.Substring(0,2));
        }


    }
}