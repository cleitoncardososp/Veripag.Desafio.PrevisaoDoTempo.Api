﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context;

#nullable disable

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Migrations
{
    [DbContext(typeof(PrevisaoDoTempoContext))]
    [Migration("20240626150531_FlagTipoDePrevisao")]
    partial class FlagTipoDePrevisao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.HistoricoBusca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CidadePesquisada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataBusca")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoPrevisao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HistoricoDeBuscas");
                });

            modelBuilder.Entity("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.PrevisaoAtual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescricaoTempo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HistoricoBuscaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Temperatura")
                        .HasColumnType("float");

                    b.Property<double>("Umidade")
                        .HasColumnType("float");

                    b.Property<double>("VelocidadeVento")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoBuscaId");

                    b.ToTable("PrevisaoAtual");
                });

            modelBuilder.Entity("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.PrevisaoEstendida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescricaoTempo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HistoricoBuscaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Temperatura")
                        .HasColumnType("float");

                    b.Property<double>("Umidade")
                        .HasColumnType("float");

                    b.Property<double>("VelocidadeVento")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoBuscaId");

                    b.ToTable("PrevisaoEstendidas");
                });

            modelBuilder.Entity("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.PrevisaoAtual", b =>
                {
                    b.HasOne("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.HistoricoBusca", "HistoricoBusca")
                        .WithMany()
                        .HasForeignKey("HistoricoBuscaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistoricoBusca");
                });

            modelBuilder.Entity("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.PrevisaoEstendida", b =>
                {
                    b.HasOne("Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.HistoricoBusca", "HistoricoBusca")
                        .WithMany()
                        .HasForeignKey("HistoricoBuscaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistoricoBusca");
                });
#pragma warning restore 612, 618
        }
    }
}
