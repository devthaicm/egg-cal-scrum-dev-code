using System;
using System.Collections.Generic;

namespace eggCal
{
    class ProcessBomOfEgg
    {
        public int servTime { get; set; }
        public int oil { get; set; }
        public int friedTime { get; set; }

    }

    class ProcessEggRequest
    {
        public int personNumber { get; set; }
        public int egg { get; set; }
    }

    class ProcessEggResponse
    {
        public int oil { get; set; }
        public int minute { get; set; }
    }



    class Program
    {

        static void Main(string[] args)
        {
            //// input 
            //int personNumber = 1;
            //int eggPerson = 2;

            //// process 
            //int minute, servTime, friedTime, oil;
            //servTime = personNumber * 2;
            //friedTime = eggPerson * 5;
            //minute = servTime + friedTime;
            //oil = eggPerson * 2;

            //Console.WriteLine("time : " + minute + " oil : " + oil);


            //ProcessEggResponse processEggResponse = EggCalProcess(new ProcessEggRequest() { egg = 2, personNumber = 1 });
            //// out put 
            //Console.WriteLine("time : " + processEggResponse.minute + " oil : " + processEggResponse.oil);


            //ProcessEggResponse processEggResponse = EggCalProcessDynamic(new ProcessEggRequest() { personNumber = 2, egg = 4 }
            //                                                            , new ProcessBomOfEgg() { servTime = 1, friedTime = 20, oil = 2 }
            //                                                              );
            //Console.WriteLine("time : " + processEggResponse.minute + " oil : " + processEggResponse.oil);


            //// input 
            List<ProcessEggRequest> ProcessEggRequests = new List<ProcessEggRequest>();
            ProcessEggRequests.Add(new ProcessEggRequest() { personNumber = 1, egg = 4  });
            ProcessEggRequests.Add(new ProcessEggRequest() { personNumber = 1, egg = 5 });
            ProcessEggRequests.Add(new ProcessEggRequest() { personNumber = 1, egg = 5 });
            ProcessEggRequests.Add(new ProcessEggRequest() { personNumber = 1, egg = 5 });


            //// process 
            List<ProcessEggResponse> processEggResponseList = new List<ProcessEggResponse>();
            ProcessEggResponse AllResult = new ProcessEggResponse();
            
            for (int i = 0; i < ProcessEggRequests.Count; i++)
            {
                ProcessEggResponse processEggResponseResult = EggCalProcess(ProcessEggRequests[i]);
                AllResult.minute += processEggResponseResult.minute;
                AllResult.oil += processEggResponseResult.oil;
                processEggResponseList.Add(processEggResponseResult);
            Console.WriteLine("N : "+i + " minute : " + processEggResponseResult.minute + "  oil : " + processEggResponseResult.oil);
            }
            Console.WriteLine( "All ( " +" minute: " + AllResult.minute + "  oil : " + AllResult.oil + ")" );
        }

        public static ProcessEggResponse EggCalProcess(ProcessEggRequest processEggRequest) {
            ProcessEggResponse processEggResponse = new ProcessEggResponse();
            int minute, servTime, friedTime, oil;
            servTime = processEggRequest.personNumber * 2;
            friedTime = processEggRequest.egg * 5;
            processEggResponse.minute = servTime + friedTime;
            processEggResponse.oil = processEggRequest.egg * 2;
            return processEggResponse;
        }

        public static ProcessEggResponse EggCalProcessX(ProcessEggRequest processEggRequest )
        {
           ProcessBomOfEgg withOneRequest = new ProcessBomOfEgg();
            withOneRequest.oil = 0;
            withOneRequest.friedTime = 1;
            withOneRequest.servTime = 2;
          return   EggCalProcessDynamic(processEggRequest, withOneRequest);
        }


        public static ProcessEggResponse EggCalProcessDynamic(ProcessEggRequest processEggRequest  , ProcessBomOfEgg withOneRequest )
        {
            ProcessEggResponse processEggResponse = new ProcessEggResponse();
            int minute, servTime, friedTime, oil;
            servTime = processEggRequest.personNumber * withOneRequest.servTime;
            friedTime = processEggRequest.egg * withOneRequest.friedTime;
            processEggResponse.minute = servTime + friedTime;
            processEggResponse.oil = processEggRequest.egg * withOneRequest.friedTime;
            return processEggResponse;
        }

    }

   

}
