// ATTQueryAgentStateConfParser.cs
using System;
using NLog;
using TSAPIClient.ATT;
using TSAPIClient.Readers;

// ReSharper disable once CheckNamespace
namespace TSAPIClient.Parsers
{
    public class ATTQueryAgentStateConfParser : IATTEventParser
    {
        public ATTEvent_t Parse(IStructReader reader)
        {
            Logger logger = LogManager.GetLogger("TSAPIClient");

            try
            {
                logger.Info("ATTQueryAgentStateConfParser.Parse: eventType=ATT_QUERY_AGENT_STATE_CONF");

                object result;

                if (reader.TryReadStruct(typeof(ATTQueryAgentStateConfEvent_t), out result))
                {
                    ATTQueryAgentStateConfEvent_t queryAgentState = (ATTQueryAgentStateConfEvent_t)result;

                    ATTEvent_t attEvent = new ATTEvent_t() { eventType = (ushort)eventType };

                    attEvent.u.queryAgentState = queryAgentState;

                    return attEvent;
                }
            }
            catch (Exception err)
            {
                logger.Error(string.Format("Error in ATTQueryAgentStateConfParser.Parse: {0}", err));
            }

            return null;
        }

        public int eventType
        {
            get { return Constants.ATT_QUERY_AGENT_STATE_CONF; }
        }
    }
}
