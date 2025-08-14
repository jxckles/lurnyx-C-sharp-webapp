using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class IsUniqueFiltered : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "$2a$12$QRPBEwjC2Ws6mMTjT7Yuke.p49AAi2OC.NhzmHyFpkX/A6WqNv6/u");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$jHExrS5VZnSP4o8Tccwvj.9DHyJWIKY5rp1.twn6OIWvklehqBuPG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$NDAL4oNhERJnAxjj./5nF.VQB6kFpIhMMM4Rp2MDRbw2Y7WvoDeeC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$j0S/DV8w9hMT57Qtyu1d4eBzJXw7io3/IzGa/8HECTiF5jF78kPym");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$12$rT40odczVhn5POSDZNHMkeu.kr81xDfX5uSWPO8oMfID2Ik.KhvGu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$12$wfkPhvJRKL2k4U2y9gCXLuC/6FJu9i0UqB.X9Vmk6ZAc.FMvjO2PS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$12$GNsYCpH5ExL5.3lVhmiicuUJlNxgaazJmdGV.8TBNWHkRd45LINL.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$12$61NpA9Lo5dKMHekeJt8SQ.FJ9/2b7ViuTZxISZPKdZzCZaBYZpLYS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$12$bfbqLgAgBwm/zHw68/B9K.tcCms2w2qtBYTLfGoi4EzQs54YN3D4O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$12$MQcleuEl2jG07DYe45ns8eZLcL5Ro3waJGoCS83JQryiUxn3lN76C");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$12$aVvzRlksKUuJUXQFi2n8Huqlv6RMZ34BPPVhiFClfWdqwlrcOCVCK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$12$qUhs676BdQElnAtWbeOWGuB1HDmD9ptLGtnPAZtSc41dquS35d6J.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$12$Zn2pm6rFEvxokqgI.G8/l.LYd75BZmveQ23UJ2lap/cEdToIgdRZa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$12$WjGDgcfM8MqnPZ3Z/2wj7OSMujrRjulEWfZNriPpCo3FYz1dQvm5e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$12$Ach8lCWs1m7qkXH1KByta.jQeYQk9JmkZMbxKYES11QlL9r7m1nrS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$12$XgbKxmTJiGovVvrurECmVuFyrhXjljiAYdpJcUsOTfProq6y3VVri");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$12$QyJ6Ae1WN4mSVu.8NErCIuhnLZZuR0RZ2Dh6hlQsvwtVZu1ODK6Za");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 18,
                column: "Password",
                value: "$2a$12$jZX2UnNNqcfJCNxcIg4ycebw0pFJNG9K8r07i7NxKERoPVy/ydEpS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 19,
                column: "Password",
                value: "$2a$12$QRPvXsVAX3EhPoI7XtKGlOKE8LfOMUWMh3JdlEPJB16LfPYJhkWIS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 20,
                column: "Password",
                value: "$2a$12$Xxfn24f5hv9yfTy8cG.0dO5UNiw/ZEIHszcpvfl51kYOCXy2hR4uy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 21,
                column: "Password",
                value: "$2a$12$7TffxXxK9d4mLKeNtsyC3OrKdtJvqojRIjNOx7K7Znb0etOpW6M4m");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_Name",
                table: "TrainingCategory",
                column: "Name",
                unique: true);
        }
    }
}
