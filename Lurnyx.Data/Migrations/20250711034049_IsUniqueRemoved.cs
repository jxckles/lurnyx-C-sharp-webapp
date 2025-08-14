using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class IsUniqueRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_TrainingCategory_Name",
                table: "TrainingCategory");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$bsPBp9bGXl7cVioJeNx3sODLgmT8AjMU067iH6bLYltN7PybseBOe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$JsW.qb6YtjzwpqyWnlRtKuSORhO3d5Et/RaP5OHNCMo0cP6EHeT0K");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$XN/RxgF.8zsLD.l9AO7f..ncylLCVf6kqsR66WzEIyITjqhkZfeA.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$AxILar4SV6tlVgap7iiCm.CVZy8pHhiaS2Y.glnLaoaWJqUbdkmse");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$12$PZuMyvKafBTrgde13sgHKeVpwAv.9SzNwoQdW41E2nW/yj/bjsuau");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$12$65XGn0AMGpZFJvaJEz/RN.PVVN11W9/L.PlFYxyevwHnazVFMXk2C");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$12$h4oxPkHPiINgZEVpiIX05.iCtufSbZ45DI9JHm8G2BlksIEvksTCK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$12$oBCarGXPvY9baWdc6CLGYOHITu6uzHYuo2h2vVJ9ymhaBU2Fz5fNG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$12$hKo/uhV9gLy3ilHYkFuF9...5kMqQKLsmN13vfplZNhJXLKV9FWoS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$12$rriM6CTm0QfC./QptWoa0.ZW8.Z7xq27dkEJujrE..24Kkt1YFGh.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$12$JoYKDMnjimv24doRjGkypu.wXTf0Pk2jcNuUWMmkj8GwqiY65wCVO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$12$NlRylVYSOrevc.90DtiWMOGzQBSzMUZko8sdwB.ig/1LTWUWLvWsW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$12$N41Wz8j58tZoam/IDipUJ.ljtALyFw9YT/UAAZO7YZ/8DNgZ9ojD.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$12$LB.SehLE7/HEviNrOWKh9uejPrjmlC60QDS8FjHHzwuaTHaqcj2Wm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$12$Om3DfGMhb2UAQazd8wyMUepDqm9p2BsDIMLzZyuWdG1H2fX2IME92");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$12$ImZkFQv0IYrBQFIuwq7BiukE4pEScbZa0DETrlwd8HUC/5YohH3C.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$12$8WR9qi7nYG3cteJ5J.wQQ.n90J4Yv3rJOKhWqfrQ9Lsdje8o/7ZJ2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 18,
                column: "Password",
                value: "$2a$12$zu3shu9UBDm4v92Y6Xxl4.AMn0VYhmo04K3AiIH3s/9yzUwnMm6Ca");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 19,
                column: "Password",
                value: "$2a$12$Wl9OYB4iQ0BQO85e7UtTbue32qUn1dDfoSGok1Vbg1ykpq1ezvOcG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 20,
                column: "Password",
                value: "$2a$12$Tf8COTwYvWejZGEjBGfgVepd7HtIG.H4NC3ZPHVI3ZRG/ieVpWKUa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 21,
                column: "Password",
                value: "$2a$12$5E8YwXnEX3zVardlOr0Eo.HF7JwH/kYA0X6tEuE7YLo/TZfIC4qnO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$qgpQprWdu.xIy3vwSIeHFuWIhfkuTrb.fUz9efOTht2uhubH0x.Wy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$5ZmW/zBYHT3kNwKqXYQXHeBq/C1ZmYMItufAME55aaLBlERhCMS96");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$m5kIQpP/NR9sZHuaGg3sIO1jbRRhbOx3fnCAAp2QU3Gpu4D6vcHQK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$9jcTl07p2B0eCg.g7OXS4u4EX./eyOJjFO8NE9yizvSzxnnHsWT72");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$12$MmbkS0GnobBfNLVCbKXPCej7h.lNMp3Js32f/yXX3AGXm0w38mDJG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$12$DT2meAd29KdCXn0XI.CCxuIw8Zv3J/z5.AR7MGLv5b5Ig0gO.Oq.O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$12$eCrcq2j6C5Aktwbd.64CbOYabPVGaI0/MMCnEtwA.c0z5xR9yOqL2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$12$6RPUda407ZaM8UTOrdDn7uMkXDuZSB1tIiqPvQ.TDTwwqItLx8mNS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$12$WRVyiZACXIwHGpHoUASKM.z3CbezCsbgLF.cCcNlSq2J51/CcMrUS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$12$yKH8sh9JYN8rF9u5WEj/beUhVf3itSNLc3njCD/UW.Yg3of4E8IIS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$12$Ds8BAX0K46ZLnLJ4FEehr.KwisPDnIsQd5wzEpN4PE6uHAmMn6efy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$12$mt.F016d2sT5dnD0EhjEj.04kw3RiyEB3Dzvqn234DFsg6pO8VlLa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$12$di250uudROmwl.tgRQE1pu5w.wNrHWKxU/go1wCWT2aAwhgY3JdBG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$12$n6U8e8x.KYDjZa4gXML0..ZpTdONs.2Nqy2EpfEuBobPAxzBMOoyG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$12$NntwR0IdAVIzDqrv6qGAW.v5GZAAMcKVvOFeJhi4VeBGod4ER3IM2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$12$CtZrTFJIcwAE7.hbSW8Rp.U2VTJW2A6XTTDFWtaQ/M/oSdN4n/7xi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$12$.4M7OB9CTBGYTemxRQJQ1eSjLySIU87sDAhPFNvsqwHJJkGHj6xYm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 18,
                column: "Password",
                value: "$2a$12$H.oQXMugPt4qEByy5Yvf/OUW/jJN64vTXqtMMQwPTmPnNWFJFOSJO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 19,
                column: "Password",
                value: "$2a$12$0ISMoxZtgWEgbMz2Pk1X6eOC0NEwObxNnI8FEgGRUJj2Um1gK72BS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 20,
                column: "Password",
                value: "$2a$12$LrHN4pcYSzZ7CI22GvyKSuB.NE7/XjzA1OkkiqyRTl5DB48ptCIby");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 21,
                column: "Password",
                value: "$2a$12$GOKJO2uq7T57w7W5hH0a5es85IPor8CTcbqVkWPjRyvsurOsNvxj2");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[DeletedAt] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_Name",
                table: "TrainingCategory",
                column: "Name",
                unique: true,
                filter: "[DeletedAt] IS NULL");
        }
    }
}
