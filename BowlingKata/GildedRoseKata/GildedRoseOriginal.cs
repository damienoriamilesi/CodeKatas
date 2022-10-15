using System.Collections.Generic;

namespace Katas.GildedRoseKata
{
    public class GildedRoseOriginal
    {
        public const string AGED_BRIE = "AgedBrie";
        public const string SULFURAS_HAND_OF_RAGNAROS = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_TO_TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

        IList<Item> _items;
        public GildedRoseOriginal(IList<Item> Items)
        {
            _items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name != AGED_BRIE && _items[i].Name != BACKSTAGE_TO_TAFKAL80ETC)
                {
                    if (_items[i].Quality > 0)
                    {
                        if (_items[i].Name != SULFURAS_HAND_OF_RAGNAROS)
                        {
                            _items[i].Quality = _items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;

                        if (_items[i].Name == BACKSTAGE_TO_TAFKAL80ETC)
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_items[i].Name != SULFURAS_HAND_OF_RAGNAROS)
                {
                    _items[i].SellIn = _items[i].SellIn - 1;
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != AGED_BRIE)
                    {
                        if (_items[i].Name != BACKSTAGE_TO_TAFKAL80ETC)
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (_items[i].Name != SULFURAS_HAND_OF_RAGNAROS)
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = _items[i].Quality - _items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality = _items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
