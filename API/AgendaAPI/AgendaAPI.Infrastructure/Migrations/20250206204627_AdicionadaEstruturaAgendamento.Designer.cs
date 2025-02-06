﻿// <auto-generated />
using System;
using AgendaAPI.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250206204627_AdicionadaEstruturaAgendamento")]
    partial class AdicionadaEstruturaAgendamento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaAPI.Domain.Entities.Agenda.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHorario");

                    b.ToTable("Agendamento", (string)null);
                });

            modelBuilder.Entity("AgendaAPI.Domain.Entities.Agenda.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Disponibilidade")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HorarioFim")
                        .HasColumnType("time(0)");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time(0)");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<double>("ValorConsulta")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Horario", (string)null);
                });

            modelBuilder.Entity("AgendaAPI.Domain.Entities.Agenda.Agendamento", b =>
                {
                    b.HasOne("AgendaAPI.Domain.Entities.Agenda.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Horario");
                });
#pragma warning restore 612, 618
        }
    }
}
