﻿using System.Diagnostics;
using System.Linq;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeIntoWithoutUpdates
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeInto Without Updates *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities().ToList();

            source.Display("Source DTOs");
            destination.Display("Destination entity collection (before merge)");

            source.MergeInto(destination, 
                getKeyFromSource:src => src.GetEntityId(), 
                getKeyFromDest:dest => dest.Id, 
                mapAdd:src => new Person(src.GetEntityId(), src.Name));

            destination.Display("Destination entity collection (after merge)");
        }
    }
}
