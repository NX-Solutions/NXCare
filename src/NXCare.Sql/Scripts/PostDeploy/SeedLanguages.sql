﻿SET IDENTITY_INSERT [dbo].[Language] ON 

BEGIN TRANSACTION;

BEGIN TRY  

declare @languageTempTable TABLE
(
	[Id]                 INT,
	[NativeName]         NVARCHAR(80) NOT NULL,
	[NameTranslationKey] VARCHAR(80)  NOT NULL,
	[Alpha2Code]         VARCHAR(2)   NOT NULL,
	[Alpha3Code]         VARCHAR(3)   NOT NULL
)
INSERT INTO @languageTempTable ([Id], [NativeName], [NameTranslationKey], [Alpha2Code], [Alpha3Code]) VALUES
(1,N'Afaraf',N'Afar',N'aa',N'aar'),
(2,N'аҧсуа бызшәа, аҧсшәа',N'Abkhaz',N'ab',N'abk'),
(3,N'avesta',N'Avestan',N'ae',N'ave'),
(4,N'Afrikaans',N'Afrikaans',N'af',N'afr'),
(5,N'Akan',N'Akan',N'ak',N'aka'),
(6,N'አማርኛ',N'Amharic',N'am',N'amh'),
(7,N'aragonés',N'Aragonese',N'an',N'arg'),
(8,N'العربية',N'Arabic',N'ar',N'ara'),
(9,N'অসমীয়া',N'Assamese',N'as',N'asm'),
(10,N'авар мацӀ, магӀарул мацӀ',N'Avaric',N'av',N'ava'),
(11,N'aymar aru',N'Aymara',N'ay',N'aym'),
(12,N'azərbaycan dili',N'Azerbaijani',N'az',N'aze'),
(13,N'башҡорт теле',N'Bashkir',N'ba',N'bak'),
(14,N'беларуская мова',N'Belarusian',N'be',N'bel'),
(15,N'български език',N'Bulgarian',N'bg',N'bul'),
(16,N'भोजपुरी',N'Bihari',N'bh',N'bih'),
(17,N'Bislama',N'Bislama',N'bi',N'bis'),
(18,N'bamanankan',N'Bambara',N'bm',N'bam'),
(19,N'বাংলা',N'Bengali, Bangla',N'bn',N'ben'),
(20,N'བོད་ཡིག',N'Tibetan Standard, Tibetan, Central',N'bo',N'bod'),
(21,N'brezhoneg',N'Breton',N'br',N'bre'),
(22,N'bosanski jezik',N'Bosnian',N'bs',N'bos'),
(23,N'català',N'Catalan',N'ca',N'cat'),
(24,N'нохчийн мотт',N'Chechen',N'ce',N'che'),
(25,N'Chamoru',N'Chamorro',N'ch',N'cha'),
(26,N'corsu, lingua corsa',N'Corsican',N'co',N'cos'),
(27,N'ᓀᐦᐃᔭᐍᐏᐣ',N'Cree',N'cr',N'cre'),
(28,N'čeština, český jazyk',N'Czech',N'cs',N'ces'),
(29,N'ѩзыкъ словѣньскъ',N'Old Church Slavonic, Church Slavonic, Old Bulgarian',N'cu',N'chu'),
(30,N'чӑваш чӗлхи',N'Chuvash',N'cv',N'chv'),
(31,N'Cymraeg',N'Welsh',N'cy',N'cym'),
(32,N'dansk',N'Danish',N'da',N'dan'),
(33,N'Deutsch',N'German',N'de',N'deu'),
(34,N'ދިވެހި',N'Divehi, Dhivehi, Maldivian',N'dv',N'div'),
(35,N'རྫོང་ཁ',N'Dzongkha',N'dz',N'dzo'),
(36,N'Eʋegbe',N'Ewe',N'ee',N'ewe'),
(37,N'ελληνικά',N'Greek (modern)',N'el',N'ell'),
(38,N'English',N'English',N'en',N'eng'),
(39,N'Esperanto',N'Esperanto',N'eo',N'epo'),
(40,N'Español',N'Spanish',N'es',N'spa'),
(41,N'eesti, eesti keel',N'Estonian',N'et',N'est'),
(42,N'euskara, euskera',N'Basque',N'eu',N'eus'),
(43,N'فارسی',N'Persian (Farsi)',N'fa',N'fas'),
(44,N'Fulfulde, Pulaar, Pular',N'Fula, Fulah, Pulaar, Pular',N'ff',N'ful'),
(45,N'suomi, suomen kieli',N'Finnish',N'fi',N'fin'),
(46,N'vosa Vakaviti',N'Fijian',N'fj',N'fij'),
(47,N'føroyskt',N'Faroese',N'fo',N'fao'),
(48,N'français, langue française',N'French',N'fr',N'fra'),
(49,N'Frysk',N'Western Frisian',N'fy',N'fry'),
(50,N'Gaeilge',N'Irish',N'ga',N'gle'),
(51,N'Gàidhlig',N'Scottish Gaelic, Gaelic',N'gd',N'gla'),
(52,N'galego',N'Galician',N'gl',N'glg'),
(53,N'Avañe''ẽ',N'Guaraní',N'gn',N'grn'),
(54,N'ગુજરાતી',N'Gujarati',N'gu',N'guj'),
(55,N'Gaelg, Gailck',N'Manx',N'gv',N'glv'),
(56,N'(Hausa) هَوُسَ',N'Hausa',N'ha',N'hau'),
(57,N'עברית',N'Hebrew (modern)',N'he',N'heb'),
(58,N'हिन्दी, हिंदी',N'Hindi',N'hi',N'hin'),
(59,N'Hiri Motu',N'Hiri Motu',N'ho',N'hmo'),
(60,N'hrvatski jezik',N'Croatian',N'hr',N'hrv'),
(61,N'Kreyòl ayisyen',N'Haitian, Haitian Creole',N'ht',N'hat'),
(62,N'magyar',N'Hungarian',N'hu',N'hun'),
(63,N'Հայերեն',N'Armenian',N'hy',N'hye'),
(64,N'Otjiherero',N'Herero',N'hz',N'her'),
(65,N'Interlingua',N'Interlingua',N'ia',N'ina'),
(66,N'Bahasa Indonesia',N'Indonesian',N'id',N'ind'),
(67,N'Originally called Occidental; then Interlingue after WWII',N'Interlingue',N'ie',N'ile'),
(68,N'Asụsụ Igbo',N'Igbo',N'ig',N'ibo'),
(69,N'ꆈꌠ꒿ Nuosuhxop',N'Nuosu',N'ii',N'iii'),
(70,N'Iñupiaq, Iñupiatun',N'Inupiaq',N'ik',N'ipk'),
(71,N'Ido',N'Ido',N'io',N'ido'),
(72,N'Íslenska',N'Icelandic',N'is',N'isl'),
(73,N'Italiano',N'Italian',N'it',N'ita'),
(74,N'ᐃᓄᒃᑎᑐᑦ',N'Inuktitut',N'iu',N'iku'),
(75,N'日本語 (にほんご)',N'Japanese',N'ja',N'jpn'),
(76,N'ꦧꦱꦗꦮ, Basa Jawa',N'Javanese',N'jv',N'jav'),
(77,N'ქართული',N'Georgian',N'ka',N'kat'),
(78,N'Kikongo',N'Kongo',N'kg',N'kon'),
(79,N'Gĩkũyũ',N'Kikuyu, Gikuyu',N'ki',N'kik'),
(80,N'Kuanyama',N'Kwanyama, Kuanyama',N'kj',N'kua'),
(81,N'қазақ тілі',N'Kazakh',N'kk',N'kaz'),
(82,N'kalaallisut, kalaallit oqaasii',N'Kalaallisut, Greenlandic',N'kl',N'kal'),
(83,N'ខ្មែរ, ខេមរភាសា, ភាសាខ្មែរ',N'Khmer',N'km',N'khm'),
(84,N'ಕನ್ನಡ',N'Kannada',N'kn',N'kan'),
(85,N'한국어',N'Korean',N'ko',N'kor'),
(86,N'Kanuri',N'Kanuri',N'kr',N'kau'),
(87,N'कश्मीरी, كشميري‎',N'Kashmiri',N'ks',N'kas'),
(88,N'Kurdî, كوردی‎',N'Kurdish',N'ku',N'kur'),
(89,N'коми кыв',N'Komi',N'kv',N'kom'),
(90,N'Kernewek',N'Cornish',N'kw',N'cor'),
(91,N'Кыргызча, Кыргыз тили',N'Kyrgyz',N'ky',N'kir'),
(92,N'latine, lingua latina',N'Latin',N'la',N'lat'),
(93,N'Lëtzebuergesch',N'Luxembourgish, Letzeburgesch',N'lb',N'ltz'),
(94,N'Luganda',N'Ganda',N'lg',N'lug'),
(95,N'Limburgs',N'Limburgish, Limburgan, Limburger',N'li',N'lim'),
(96,N'Lingála',N'Lingala',N'ln',N'lin'),
(97,N'ພາສາລາວ',N'Lao',N'lo',N'lao'),
(98,N'lietuvių kalba',N'Lithuanian',N'lt',N'lit'),
(99,N'Tshiluba',N'Luba-Katanga',N'lu',N'lub'),
(100,N'latviešu valoda',N'Latvian',N'lv',N'lav'),
(101,N'fiteny malagasy',N'Malagasy',N'mg',N'mlg'),
(102,N'Kajin M̧ajeļ',N'Marshallese',N'mh',N'mah'),
(103,N'te reo Māori',N'Māori',N'mi',N'mri'),
(104,N'македонски јазик',N'Macedonian',N'mk',N'mkd'),
(105,N'മലയാളം',N'Malayalam',N'ml',N'mal'),
(106,N'Монгол хэл',N'Mongolian',N'mn',N'mon'),
(107,N'मराठी',N'Marathi (Marāṭhī)',N'mr',N'mar'),
(108,N'bahasa Melayu, بهاس ملايو‎',N'Malay',N'ms',N'msa'),
(109,N'Malti',N'Maltese',N'mt',N'mlt'),
(110,N'ဗမာစာ',N'Burmese',N'my',N'mya'),
(111,N'Dorerin Naoero',N'Nauruan',N'na',N'nau'),
(112,N'Norsk bokmål',N'Norwegian Bokmål',N'nb',N'nob'),
(113,N'isiNdebele',N'Northern Ndebele',N'nd',N'nde'),
(114,N'नेपाली',N'Nepali',N'ne',N'nep'),
(115,N'Owambo',N'Ndonga',N'ng',N'ndo'),
(116,N'Nederlands, Vlaams',N'Dutch',N'nl',N'nld'),
(117,N'Norsk nynorsk',N'Norwegian Nynorsk',N'nn',N'nno'),
(118,N'Norsk',N'Norwegian',N'no',N'nor'),
(119,N'isiNdebele',N'Southern Ndebele',N'nr',N'nbl'),
(120,N'Diné bizaad',N'Navajo, Navaho',N'nv',N'nav'),
(121,N'chiCheŵa, chinyanja',N'Chichewa, Chewa, Nyanja',N'ny',N'nya'),
(122,N'occitan, lenga d''òc',N'Occitan',N'oc',N'oci'),
(123,N'ᐊᓂᔑᓈᐯᒧᐎᓐ',N'Ojibwe, Ojibwa',N'oj',N'oji'),
(124,N'Afaan Oromoo',N'Oromo',N'om',N'orm'),
(125,N'ଓଡ଼ିଆ',N'Oriya',N'or',N'ori'),
(126,N'ирон æвзаг',N'Ossetian, Ossetic',N'os',N'oss'),
(127,N'ਪੰਜਾਬੀ',N'(Eastern) Punjabi',N'pa',N'pan'),
(128,N'पाऴि',N'Pāli',N'pi',N'pli'),
(129,N'język polski, polszczyzna',N'Polish',N'pl',N'pol'),
(130,N'پښتو',N'Pashto, Pushto',N'ps',N'pus'),
(131,N'Português',N'Portuguese',N'pt',N'por'),
(132,N'Runa Simi, Kichwa',N'Quechua',N'qu',N'que'),
(133,N'rumantsch grischun',N'Romansh',N'rm',N'roh'),
(134,N'Ikirundi',N'Kirundi',N'rn',N'run'),
(135,N'Română',N'Romanian',N'ro',N'ron'),
(136,N'Русский',N'Russian',N'ru',N'rus'),
(137,N'Ikinyarwanda',N'Kinyarwanda',N'rw',N'kin'),
(138,N'संस्कृतम्',N'Sanskrit (Saṁskṛta)',N'sa',N'san'),
(139,N'sardu',N'Sardinian',N'sc',N'srd'),
(140,N'सिन्धी, سنڌي، سندھی‎',N'Sindhi',N'sd',N'snd'),
(141,N'Davvisámegiella',N'Northern Sami',N'se',N'sme'),
(142,N'yângâ tî sängö',N'Sango',N'sg',N'sag'),
(143,N'සිංහල',N'Sinhalese, Sinhala',N'si',N'sin'),
(144,N'slovenčina, slovenský jazyk',N'Slovak',N'sk',N'slk'),
(145,N'slovenski jezik, slovenščina',N'Slovene',N'sl',N'slv'),
(146,N'gagana fa''a Samoa',N'Samoan',N'sm',N'smo'),
(147,N'chiShona',N'Shona',N'sn',N'sna'),
(148,N'Soomaaliga, af Soomaali',N'Somali',N'so',N'som'),
(149,N'Shqip',N'Albanian',N'sq',N'sqi'),
(150,N'српски језик',N'Serbian',N'sr',N'srp'),
(151,N'SiSwati',N'Swati',N'ss',N'ssw'),
(152,N'Sesotho',N'Southern Sotho',N'st',N'sot'),
(153,N'Basa Sunda',N'Sundanese',N'su',N'sun'),
(154,N'svenska',N'Swedish',N'sv',N'swe'),
(155,N'Kiswahili',N'Swahili',N'sw',N'swa'),
(156,N'தமிழ்',N'Tamil',N'ta',N'tam'),
(157,N'తెలుగు',N'Telugu',N'te',N'tel'),
(158,N'тоҷикӣ, toçikī, تاجیکی‎',N'Tajik',N'tg',N'tgk'),
(159,N'ไทย',N'Thai',N'th',N'tha'),
(160,N'ትግርኛ',N'Tigrinya',N'ti',N'tir'),
(161,N'Türkmen, Түркмен',N'Turkmen',N'tk',N'tuk'),
(162,N'Wikang Tagalog',N'Tagalog',N'tl',N'tgl'),
(163,N'Setswana',N'Tswana',N'tn',N'tsn'),
(164,N'faka Tonga',N'Tonga (Tonga Islands)',N'to',N'ton'),
(165,N'Türkçe',N'Turkish',N'tr',N'tur'),
(166,N'Xitsonga',N'Tsonga',N'ts',N'tso'),
(167,N'татар теле, tatar tele',N'Tatar',N'tt',N'tat'),
(168,N'Twi',N'Twi',N'tw',N'twi'),
(169,N'Reo Tahiti',N'Tahitian',N'ty',N'tah'),
(170,N'ئۇيغۇرچە‎, Uyghurche',N'Uyghur',N'ug',N'uig'),
(171,N'Українська',N'Ukrainian',N'uk',N'ukr'),
(172,N'اردو',N'Urdu',N'ur',N'urd'),
(173,N'Oʻzbek, Ўзбек, أۇزبېك‎',N'Uzbek',N'uz',N'uzb'),
(174,N'Tshivenḓa',N'Venda',N've',N'ven'),
(175,N'Tiếng Việt',N'Vietnamese',N'vi',N'vie'),
(176,N'Volapük',N'Volapük',N'vo',N'vol'),
(177,N'walon',N'Walloon',N'wa',N'wln'),
(178,N'Wollof',N'Wolof',N'wo',N'wol'),
(179,N'isiXhosa',N'Xhosa',N'xh',N'xho'),
(180,N'ייִדיש',N'Yiddish',N'yi',N'yid'),
(181,N'Yorùbá',N'Yoruba',N'yo',N'yor'),
(182,N'Saɯ cueŋƅ, Saw cuengh',N'Zhuang, Chuang',N'za',N'zha'),
(183,N'中文 (Zhōngwén), 汉语, 漢語',N'Chinese',N'zh',N'zho'),
(184,N'isiZulu',N'Zulu',N'zu',N'zul')

MERGE [Language] AS TARGET
USING @languageTempTable AS SOURCE
ON (TARGET.Id = SOURCE.Id)

WHEN MATCHED THEN
    UPDATE SET TARGET.NativeName = SOURCE.NativeName, TARGET.Alpha2Code = SOURCE.Alpha2Code, TARGET.Alpha3Code = SOURCE.Alpha3Code, TARGET.NameTranslationKey = SOURCE.NameTranslationKey
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [NativeName], [NameTranslationKey], [Alpha2Code], [Alpha3Code]) VALUES (SOURCE.[Id], SOURCE.[NativeName], SOURCE.[NameTranslationKey], SOURCE.[Alpha2Code], SOURCE.[Alpha3Code]);

END TRY
BEGIN CATCH  
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;

     IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;

     THROW;
END CATCH  

IF @@TRANCOUNT > 0
    COMMIT TRANSACTION;  
GO 

SET IDENTITY_INSERT [dbo].[Language] OFF