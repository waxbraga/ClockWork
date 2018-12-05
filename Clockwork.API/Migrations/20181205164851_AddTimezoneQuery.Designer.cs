﻿// <auto-generated />
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Clockwork.API.Migrations
{
    [DbContext(typeof(ClockworkContext))]
    [Migration("20181205164851_AddTimezoneQuery")]
    partial class AddTimezoneQuery
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Clockwork.API.Models.CurrentTimeQuery", b =>
                {
                    b.Property<int>("CurrentTimeQueryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientIp");

                    b.Property<DateTime>("Time");

                    b.Property<DateTime>("UTCTime");

                    b.HasKey("CurrentTimeQueryId");

                    b.ToTable("CurrentTimeQueries");
                });

            modelBuilder.Entity("Clockwork.API.Models.TimezoneQuery", b =>
                {
                    b.Property<int>("TimezoneQueryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ConvertedTime");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Timezone");

                    b.HasKey("TimezoneQueryId");

                    b.ToTable("TimezoneQueries");
                });
#pragma warning restore 612, 618
        }
    }
}