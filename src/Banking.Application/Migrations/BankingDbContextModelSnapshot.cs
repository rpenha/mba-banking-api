﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Banking.Application.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Banking.Application.Migrations
{
    [DbContext(typeof(BankingDbContext))]
    partial class BankingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Banking.Core.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)")
                        .HasColumnName("account_number");

                    b.Property<string>("BankBranch")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("bank_branch");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("currency");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<string>("account_type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("account_type");

                    b.ComplexProperty<Dictionary<string, object>>("Balance", "Banking.Core.Accounts.Account.Balance#Money", b1 =>
                        {
                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("balance_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("balance_currency");
                        });

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("BankBranch", "AccountNumber")
                        .HasDatabaseName("ix_accounts_bank_branch_account_number");

                    b.ToTable("accounts", (string)null);

                    b.HasDiscriminator<string>("account_type").HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Banking.Core.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("tax_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Banking.Core.Customers.Customer.Name#PersonName", b1 =>
                        {
                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("name_first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("name_last_name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.HasIndex("TaxId")
                        .IsUnique()
                        .HasDatabaseName("ix_customers_tax_id");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("Banking.Core.Transactions.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("description");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("direction");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<string>("transaction_type")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("transaction_type");

                    b.ComplexProperty<Dictionary<string, object>>("Value", "Banking.Core.Transactions.Transaction.Value#Money", b1 =>
                        {
                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("value_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("value_currency");
                        });

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("AccountId", "Timestamp")
                        .IsDescending(false, true)
                        .HasDatabaseName("ix_transactions_account_id_timestamp");

                    b.ToTable("transactions", (string)null);

                    b.HasDiscriminator<string>("transaction_type").HasValue("Transaction");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Banking.Core.Accounts.CheckingAccount", b =>
                {
                    b.HasBaseType("Banking.Core.Accounts.Account");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<bool>("IsUsingLimit")
                        .HasColumnType("boolean")
                        .HasColumnName("is_using_limit");

                    b.ComplexProperty<Dictionary<string, object>>("CurrentLimit", "Banking.Core.Accounts.CheckingAccount.CurrentLimit#Money", b1 =>
                        {
                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("current_limit_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("current_limit_currency");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("TotalLimit", "Banking.Core.Accounts.CheckingAccount.TotalLimit#Money", b1 =>
                        {
                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("total_limit_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("total_limit_currency");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("UsedLimit", "Banking.Core.Accounts.CheckingAccount.UsedLimit#Money", b1 =>
                        {
                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("used_limit_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("used_limit_currency");
                        });

                    b.ToTable("accounts", (string)null);

                    b.HasDiscriminator().HasValue("checking_account");
                });

            modelBuilder.Entity("Banking.Core.Transactions.Deposit", b =>
                {
                    b.HasBaseType("Banking.Core.Transactions.Transaction");

                    b.ToTable("transactions", (string)null);

                    b.HasDiscriminator().HasValue("deposit");
                });

            modelBuilder.Entity("Banking.Core.Transactions.Withdraw", b =>
                {
                    b.HasBaseType("Banking.Core.Transactions.Transaction");

                    b.ToTable("transactions", (string)null);

                    b.HasDiscriminator().HasValue("withdraw");
                });
#pragma warning restore 612, 618
        }
    }
}
