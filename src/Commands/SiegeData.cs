using System.Collections.Generic;

/// <summary>
/// Dictionaries to convert data scraped from r6tracker into respective rank images and colors.
/// </summary>
public class SiegeData
{
    //Rank Icons
    public Dictionary<string, string> rankImages = new Dictionary<string, string>()
    {
        {"Not ranked yet.", "https://cdn.discordapp.com/attachments/749632541228531732/749644282310426644/Unranked.png"},

        {"COPPER V", "https://cdn.discordapp.com/attachments/749632541228531732/749644060435677253/Copper_V.png"},
        {"COPPER IV", "https://cdn.discordapp.com/attachments/749632541228531732/749644050700697712/Copper_IV.png"},
        {"COPPER III", "https://cdn.discordapp.com/attachments/749632541228531732/749644049111187468/Copper_III.png"},
        {"COPPER II", "https://cdn.discordapp.com/attachments/749632541228531732/749644047789981749/Copper_II.png"},
        {"COPPER I", "https://cdn.discordapp.com/attachments/749632541228531732/749644046368112640/Copper_I.png"},

        {"BRONZE V", "https://discordapp.com/channels/734926760348745830/749632541228531732/749644122121437254"},
        {"BRONZE IV", "https://cdn.discordapp.com/attachments/749632541228531732/749644118820388883/Bronze_IV.png"},
        {"BRONZE III", "https://cdn.discordapp.com/attachments/749632541228531732/749644117369290803/Bronze_III.png"},
        {"BRONZE II", "https://cdn.discordapp.com/attachments/749632541228531732/749644115951747172/Bronze_II.png"},
        {"BRONZE I", "https://cdn.discordapp.com/attachments/749632541228531732/749644112923328522/Bronze_I.png"},

        {"SILVER V", "https://cdn.discordapp.com/attachments/749632541228531732/749644156229386341/Silver_V.png"},
        {"SILVER IV", "https://cdn.discordapp.com/attachments/749632541228531732/749644154686144552/Silver_IV.png"},
        {"SILVER III", "https://cdn.discordapp.com/attachments/749632541228531732/749644153293504512/Silver_III.png"},
        {"SILVER II", "https://cdn.discordapp.com/attachments/749632541228531732/749644151892738079/Silver_II.png"},
        {"SILVER I", "https://cdn.discordapp.com/attachments/749632541228531732/749644150399565865/Silver_I.png"},

        {"GOLD III", "https://cdn.discordapp.com/attachments/749632541228531732/749644186634027028/Gold_III.png"},
        {"GOLD II", "https://cdn.discordapp.com/attachments/749632541228531732/749644185690439781/Gold_II.png"},
        {"GOLD I", "https://cdn.discordapp.com/attachments/749632541228531732/749644184201461840/Gold_I.png"},

        {"PLATINUM III", "https://cdn.discordapp.com/attachments/749632541228531732/749644221795008652/Platinum_III.png"},
        {"PLATINUM II", "https://cdn.discordapp.com/attachments/749632541228531732/749644213393686550/Platinum_II.png"},
        {"PLATINUM I", "https://cdn.discordapp.com/attachments/749632541228531732/749644211908903001/Platinum_I.png"},

        {"DIAMOND", "https://cdn.discordapp.com/attachments/749632541228531732/749644249485803560/Diamond.png"},

        {"CHAMPIONS", "https://cdn.discordapp.com/attachments/749632541228531732/749644267378573353/Champion.png"}
    };

    //Rank Colors
    public Dictionary<string, uint> rankColors = new Dictionary<string, uint>()
    {
        {"Not ranked yet.", 0x231f20},

        {"COPPER V", 0x7c2b00},
        {"COPPER IV", 0x7c2b00},
        {"COPPER III", 0x7c2b00},
        {"COPPER II", 0x7c2b00},
        {"COPPER I", 0x7c2b00},

        {"BRONZE V", 0xbc783c},
        {"BRONZE IV", 0xbc783c},
        {"BRONZE III", 0xbc783c},
        {"BRONZE II", 0xbc783c},
        {"BRONZE I", 0xbc783c},

        {"SILVER V", 0xa5a5a5},
        {"SILVER IV", 0xa5a5a5},
        {"SILVER III", 0xa5a5a5},
        {"SILVER II", 0xa5a5a5},
        {"SILVER I", 0xa5a5a5},

        {"GOLD III", 0xedaf35},
        {"GOLD II", 0xedaf35},
        {"GOLD I", 0xedaf35},

        {"PLATINUM III", 0x44ccc0},
        {"PLATINUM II", 0x44ccc0},
        {"PLATINUM I", 0x44ccc0},

        {"DIAMOND", 0x9a7cf4},

        {"CHAMPIONS", 0xe01669}
    };
}
