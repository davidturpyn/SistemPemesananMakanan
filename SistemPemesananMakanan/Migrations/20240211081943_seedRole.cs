using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemPemesananMakanan.Migrations
{
    public partial class seedRole : Migration
    {
        private string kasirRole = Guid.NewGuid().ToString();
        private string pelayanRole = Guid.NewGuid().ToString();


        private string UserId1 = Guid.NewGuid().ToString();
        private string UserId2 = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRoles(migrationBuilder);
            SeedUser(migrationBuilder);
            SeedUserRoles(migrationBuilder);
        }

        private void SeedRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
            VALUES
           ('{kasirRole}'
           ,'kasir'
           ,'KASIR'
           ,null)");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
            VALUES
           ('{pelayanRole}'
           ,'pelayan'
           ,'PELAYAN'
           ,null)");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[firstName]
           ,[lastName]
           ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
            VALUES
           (N'{UserId1}'
           ,N'tes3'
           ,N'Lastname'
           ,N'tes3@tes.com'
           ,N'TES3@TES.COM'
           ,N'tes3@tes.com'
           ,N'TES3@TES.COM'
           ,0
           ,'AQAAAAEAACcQAAAAECVbfwr3sMT6Zz6lhAs4JMUvgyXoifjI+aZOITW0gI36EBaRXfH1lwEKclHEOX6IFA=='
           ,'NBK2OLJIHKG47DXIG63U3PPIW3CAFBPA'
           ,'e8c50978-a4c0-4824-b8ac-49babbc890ec'
           ,null
           ,0
           ,0
           ,null
           ,1
           ,0)");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[firstName]
           ,[lastName]
           ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
            VALUES
           (N'{UserId2}'
           ,N'tes2'
           ,N'Lastname'
           ,N'tes2@tes.com'
           ,N'TES2@TES.COM'
           ,N'tes2@tes.com'
           ,N'TES2@TES.COM'
           ,0
           ,'AQAAAAEAACcQAAAAECVbfwr3sMT6Zz6lhAs4JMUvgyXoifjI+aZOITW0gI36EBaRXfH1lwEKclHEOX6IFA=='
           ,'NBK2OLJIHKG47DXIG63U3PPIW3CAFBPA'
           ,'e8c50978-a4c0-4824-b8ac-49babbc890ec'
           ,null
           ,0
           ,0
           ,null
           ,1
           ,0)");
        }
        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
            VALUES
           ('{UserId1}'
           ,'{kasirRole}')");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
            VALUES
           ('{UserId2}'
           ,'{pelayanRole}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
