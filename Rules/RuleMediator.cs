using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.IO;

namespace Rules
{
    public static class RulesMediator
    {
        const string RULESCONNECTIONSTRINGNAME = "RuleSetStoreConnectionString";
        static Dictionary<string, RuleSet> ruleCache;
        static RulesMediator()
        {
            ruleCache = new Dictionary<string, RuleSet>();
        }
        public static RuleSet GetRules(string ruleSetName)
        {
            if (ruleCache.ContainsKey(ruleSetName))
                return ruleCache[ruleSetName];
            else
            {
                RuleSet rules = GetRuleSet(ruleSetName);
                ruleCache[ruleSetName] = rules;
                return rules;
            }
        }
        public static void RunRules<T>(T target, string rulesName)
        {
            RuleSet rules = GetRules(rulesName);
            RuleEngine engine = new RuleEngine(rules, typeof(T));
            engine.Execute(target);
        }
        private static RuleSet GetRuleSet(string ruleSetName)
        {
            using (SqlConnection cnn = new SqlConnection(
            ConfigurationManager.ConnectionStrings[RULESCONNECTIONSTRINGNAME].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 [RuleSet] FROM RuleSet WHERE Name=@name ORDER BY MajorVersion DESC , MinorVersion DESC",
                cnn))
                {
                    cmd.Parameters.Add("@name",
                          System.Data.SqlDbType.NVarChar, 128);
                    cmd.Parameters["@name"].Value = ruleSetName;
                    cnn.Open();
                    string rules = cmd.ExecuteScalar().ToString();
                    WorkflowMarkupSerializer serializer =
                           new WorkflowMarkupSerializer();
           RuleSet ruleset =
                          (RuleSet)serializer.Deserialize(
                                 XmlReader.Create(
                                        new StringReader(rules)));
                    return ruleset;
                }
            }
        }


    }
}
