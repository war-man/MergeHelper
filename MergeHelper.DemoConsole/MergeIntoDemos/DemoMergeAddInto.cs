﻿using System.Diagnostics;
using System.Linq;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeAddInto
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeAddInto *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities().ToList();

            source.Display("Source DTOs");
            destination.Display("Destination entity collection (before merge)");

            source.MergeAddInto(destination, 
                getKeyFromSource:src => src.Id, 
                getKeyFromDest:dest => dest.Id, 
                mapAdd:src => new Person(src.Id, src.Name));

            destination.Display("Destination entity collection (after merge)");
        }
    }
}