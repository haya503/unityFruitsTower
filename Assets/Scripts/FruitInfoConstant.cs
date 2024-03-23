using System;
using System.Collections.Generic;

/// <summary>
///  フルーツに関するクラス
/// </summary>
public class FruitInfoConstant
{
    // フルーツのプレハブの名前のマップ(キー：フルーツの名前、値：プレハブ名)
    public static readonly Dictionary<string, string> FRUITS_PREHAB_NAMES_MAP = new Dictionary<string, string>
    {
        {"ブルーベリー", "fruit_short_korogaru_blueberry"}
        ,{"イチゴ", "fruit_short_korogaranai_strawberry"}
        ,{"サクランボ", "fruit_short_hennakatachi_cherry"}
        ,{"モモ", "fruit_middle_korogaru_peach"}
        ,{"リンゴ", "fruit_middle_korogaru_apple"}
        ,{"オレンジ", "fruit_middle_korogaru_orange"}
        ,{"マスカット", "fruit_middle_korogaranai_muscut"}
        ,{"スターフルーツ", "fruit_middle_hennakatachi_starfruit"}
        ,{"メロン", "fruit_long_korogaru_melon"}
        ,{"パイナップル", "fruit_long_korogaranai_pineapple"}
        ,{"バナナ", "fruit_long_hennakatachi_banana"}
    };
}