using System;
using System.Collections.Generic;

namespace Katas.GildedRoseKata
{
    public class GildedRose
    {
        public const string AGED_BRIE = "AgedBrie";
        public const string SULFURAS_HAND_OF_RAGNAROS = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_TO_TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

        public const string DEXTERITY_VEST = "+5 Dexterity Vest";
        public const string MANGOOSE_ELIXIR = "Elixir of the Mongoose";
        public const string CONJURED_MANA_CAKE = "Conjured Mana Cake";
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> Items)
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

        public void UpdateQualityRefactored()
        {
            foreach (var item in _items)
            {
                switch(item.Name)
                {
                    case AGED_BRIE:
                        {
                            //new AgedBrie().SellInDecrease();
                            item.SellIn -= 1;
                        }
                        break;
                    case SULFURAS_HAND_OF_RAGNAROS:
                        {
                            //new Sulfura().SellInDecrease();
                        }
                        break;
                    case BACKSTAGE_TO_TAFKAL80ETC:
                        {
                            //new BackstagePassConcert().SellInDecrease();
                            item.SellIn -= 1;
                        }
                        break;
                    default:
                        {
                            if (item.SellIn > 0) item.SellIn -= 1;
                        }
                        break;
                }
            }
        }
    }


    public abstract class Good
    {
        public abstract void SellInDecrease();
        public virtual int MaxQuality { get; set; } = 50;
        public int Quality { get; set; }
    }

    public class AgedBrie : Good
    {
        public override void SellInDecrease()
        {
            throw new NotImplementedException();
        }
    }

    public class BackstagePassConcert : Good
    {
        public override void SellInDecrease()
        {
            throw new NotImplementedException();
        }
    }

    public class Sulfura : Good
    {
        public override void SellInDecrease()
        {
            Quality = 0;
        }
    }
}