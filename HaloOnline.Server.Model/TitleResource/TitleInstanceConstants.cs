namespace HaloOnline.Server.Model.TitleResource
{
    public static class TitleInstanceConstants
    {
        // Class names
        public const string TitleInstanceName = "NAME";

        public const string UiDescClassName = "UI_DESC";
        public const string GameModeClassName = "GAME_MODE";
        public const string MapInfoClassName = "MAP_INFO";
        public const string DiffPlayersClassName = "DIFF_PLAYERS";
        public const string DiffCoefClassName = "DIFF_COEF";
        public const string ItemClassName = "ITEM";
        public const string GameplayModifierClassName = "GAMEPLAY_MODIFIER";
        public const string WeaponClassName = "WEAPON";
        public const string WpnUiStatsClassName = "WPN_UI_STATS";
        public const string GrenadeClassName = "GRENADE";
        public const string BoosterClassName = "BOOSTER";
        public const string ConsumableClassName = "CONSUMABLE";
        public const string ConsUiStatsClassName = "CONS_UI_STATS";
        public const string ArmorItemClassName = "ARMOR_ITEM";
        public const string ArmorSuitClassName = "ARMOR_SUIT";
        public const string ColorClassName = "COLOR";
        public const string RewardClassName = "REWARD";
        public const string PlayerLevelClassName = "PLAYER_LEVEL";
        public const string DataMiningClassName = "DATA_MINING";
        public const string BinlogConfigClassName = "BINLOG_CONFIG";
        public const string MotdClassName = "MOTD";
        public const string AdvertismentClassName = "ADVERTISMENT";
        public const string NewsClassName = "NEWS";
        public const string ScoringEventClassName = "SCORING_EVENT";
        public const string PollyClassName = "POLLY";
        public const string DsDefaultsClassName = "DS_DEFAULTS";
        public const string ChallengeClassName = "CHALLENGE";
        public const string AccountLabelClassName = "ACCOUNT_LABEL";
        public const string AssignKitClassName = "ASSIGN_KIT";
        public const string PlaylistClassName = "PLAYLIST";
        public const string MpDefaultsClassName = "MP_DEFAULTS";


        // Properties
        
        // UI_DESC
        public const string UiDescUiNameId = "UI_NAME_ID";
        public const string UiDescUiDescId = "UI_DESC_ID";
        public const string UiDescUiDescShortId = "UI_DESC_SHORT_ID";
        public const string UiDescUiIcon = "UI_ICON";
        public const string UiDescUiIconMed = "UI_ICON_MED";
        public const string UiDescUiIconBig = "UI_ICON_BIG";
        public const string UiDescUiVideo = "UI_VIDEO";
        public const string UiDescItemQuality = "ITEM_QUALITY";
        
        // GAME_MODE
        public const string GameModeId = "ID";
        public const string GameModeSecondaryId = "SECONDARY_ID";
        public const string GameModeRoundTimeLimit = "ROUND_TIME_LIMIT";

        // MAP_INFO
        public const string MapInfoId = "ID";
        
        // DIFF_PLAYERS
        public const string DiffPlayersVitalityPlrCoef = "vitality_plr_coef"; 
        public const string DiffPlayersShieldPlrCoef = "shield_plr_coef";
        public const string DiffPlayersDamagePlrCoef = "damage_plr_coef";

        // DIFF_COEF
        public const string DiffCoefVitalityWave = "vitality_wave";
        public const string DiffCoefShieldWave = "shield_wave";
        public const string DiffCoefDamageWave = "damage_wave";
        public const string DiffCoefVitalityRound = "vitality_round";
        public const string DiffCoefShieldRound = "shield_round";
        public const string DiffCoefDamageRound = "damage_round";
        public const string DiffCoefVitalitySet = "vitality_set";
        public const string DiffCoefShieldSet = "shield_set";
        public const string DiffCoefDamageSet = "damage_set";

        public const string DiffCoefNone = "none";
        public const string DiffCoefAdd = "add";
        public const string DiffCoefMulti = "multi";

        public const string DiffCoefDiffParamScaling = "DIFF_PARAM_SCALING";
        public const string DiffCoefDiffGrowth = "DIFF_GROWTH";

        // ITEM
        public const string ItemEconomyModelType = "ECONOMY_MODEL_TYPE";
        public const string ItemCareerTree = "CAREER_TREE";
        public const string ItemRelatedChallenges = "RELATED_CHALLENGES";
        
        // GAMEPLAY_MODIFIER
        public const string GameplayModifierModifierName = "MODIFIER_NAME";
        public const string GameplayModifierModifierUnits = "MODIFIER_UNITS";
        
        // WEAPON
        public const string WeaponId = "ID";
        public const string WeaponType = "TYPE";
        
        // WPN_UI_STATS
        public const string UiWpnStatsDmg = "UI_WPN_STATS_DMG";
        public const string UiWpnStatsRof = "UI_WPN_STATS_ROF";
        public const string UiWpnStatsAcc = "UI_WPN_STATS_ACC";
        public const string UiWpnStatsClip = "UI_WPN_STATS_CLIP";
        public const string UiWpnStatsRange = "UI_WPN_STATS_RANGE";
        public const string WpnUiStatsWpnPrimaryAttribute = "WPN_PRIMARY_ATTRIBUTE";
        
        // GRENADE
        public const string GrenadeId = "ID";

        // BOOSTER
        public const string BoosterModifiers = "MODIFIERS";

        // CONSUMABLE
        public const string ConsumableIndex = "CONSUMABLE_INDEX";
        public const string ConsumableEnergyCost = "ENERGY_COST";
        public const string ConsumableCooldown = "COOLDOWN";
        public const string ConsumableCooldownInit = "COOLDOWN_INIT";

        // CONS_UI_STATS
        public const string ConsUiStatsUiConsStatsDuration = "UI_CONS_STATS_DURATION";
        public const string ConsUiStatsUiConsStatsCost = "UI_CONS_STATS_COST";
        public const string ConsUiStatsUiConsStatsCooldown = "UI_CONS_STATS_COOLDOWN";

        // ARMOR_ITEM
        public const string ArmorItemRaceId = "RACE_ID";
        public const string ArmorItemType = "TYPE";
        public const string ArmorItemObjRegion = "OBJ_REGION";
        public const string ArmorItemObjPermutation = "OBJ_PERMUTATION";
        public const string ArmorItemArmorBodyRegion = "ARMOR_BODY_REGION";
        public const string ArmorItemArmorBodyId = "ARMOR_BODY_ID";
        public const string ArmorItemArmorModifiersValues = "ARMOR_MODIFIERS_VALUES";
        public const string ArmorItemArmorModifiersList = "ARMOR_MODIFIERS_LIST";

        public const string ArmorItemHelmet = "helmet";
        public const string ArmorItemShoulder = "shoulder";
        public const string ArmorItemChest = "chest";
        public const string ArmorItemArms = "arms";
        public const string ArmorItemLegs = "legs";
        public const string ArmorItemAcc = "acc";

        // ARMOR_SUIT
        public const string ArmorSuitArmorPieceCollection = "ARMOR_PIECE_COLLECTION";

        // COLOR
        public const string ColorType = "COLOR_TYPE";
        public const string ColorR = "COLOR_R";
        public const string ColorG = "COLOR_G";
        public const string ColorB = "COLOR_B";
        public const string ColorUiListId = "UI_LIST_ID";

        public const string ColorTypePrimary = "primary";
        public const string ColorTypeSecondary = "secondary";
        public const string ColorTypeVisor = "visor";
        public const string ColorTypeLights = "lights";
        public const string ColorTypeHolo = "holo";

        // REWARD
        public const string RewardAmount = "REWARD_AMOUNT";
        public const string RewardItem = "REWARD_ITEM";

        // PLAYER_LEVEL
        public const string PlayerLevelLevelIndex = "LEVEL_INDEX";
        public const string PlayerLevelXpUnlock = "XP_UNLOCK";
        public const string PlayerLevelItemsRecieved = "ITEMS_RECIEVED";
        public const string PlayerLevelItemsUnlocked = "ITEMS_UNLOCKED";

        // DATA_MINING
        public const string DataMiningEnabled = "ENABLED";
        public const string DataMiningSessionTag = "SESSION_TAG";
        public const string DataMiningPlayerUpdateInterval = "PLAYER_UPDATE_INTERVAL";
        public const string DataMiningDebugMenuInterval = "DEBUG_MENU_INTERVAL";
        public const string DataMiningSpamEnabled = "SPAM_ENABLED";

        // MOTD
        public const string MotdUiDescId = "UI_DESC_ID";

        public const string MotdSunday = "motd_sunday";
        public const string MotdMonday = "motd_monday";
        public const string MotdTuesday = "motd_tuesday";
        public const string MotdWednesday = "motd_wednesday";
        public const string MotdThursday = "motd_thursday";
        public const string MotdFriday = "motd_friday";
        public const string MotdSaturday = "motd_saturday";

        // ADVERTISMENT
        public const string AdvertisementSortIndex = "SORT_INDEX";
        public const string AdvertisementUrl = "ADVERTISMENT_URL";
        public const string AdvertisementTimer = "ADVERTISMENT_TIMER";

        // NEWS
        public const string NewsSortIndex = "SORT_INDEX";
        public const string NewsPoster = "NEWS_POSTER";
        public const string NewsTimeStamp = "NEWS_TIME_STAMP";
        public const string NewsString = "NEWS_STRING";

        // SCORING_EVENT
        public const string ScoringEventId = "SCORING_EVENT_ID";
        public const string ScoringEventIsMedal = "IS_MEDAL";
        public const string ScoringEventScoringRewardWp = "SCORING_REWARD_WP";

        // POLLY
        public const string PollyInterval = "Interval";
        public const string PollyRetryCount = "RETRY_COUNT";

        // DS_DEFAULTS
        public const string DsDefaultsDsVotingTimer = "DS_VOTING_TIMER";
        public const string DsDefaultsDsFinalCountdownTimer = "DS_FINAL_COUNTDOWN_TIMER";

        // CHALLENGE

        // ACCOUNT_LABEL

        // ASSIGN_KIT
        public const string AssignKitOfferName = "OFFER_NAME";
        public const string AssignKitRaceId = "RACE_ID";
        public const string AssignKitWeaponToEquip = "WEAPON_TO_EQUIP";
        public const string AssignKitArmorToEquip = "ARMOR_TO_EQUIP";
        public const string AssignKitColorsToEquip = "COLORS_TO_EQUIP";

        // PLAYLIST
        public const string PlaylistGameModeCollection = "GAME_MODE_COLLECTION";
        public const string PlaylistMapCollection = "MAP_COLLECTION";
        public const string PlaylistMinPlayers = "MIN_PLAYERS";
        public const string PlaylistMaxPlayers = "MAX_PLAYERS";
        public const string PlaylistMaxParty = "MAX_PARTY";
        public const string PlaylistIsTeamPlaylist = "IS_TEAM_PLAYLIST";

        // MP_DEFAULTS
        public const string MpDefaultsDefaultPlaylist = "DEFAULT_PLAYLIST";
        public const string MpDefaultsDefaultMap = "DEFAULT_MAP";
        public const string MpDefaultsDefaultGameMode = "DEFAULT_GAME_MODE";
        
    }
}