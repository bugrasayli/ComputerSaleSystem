using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockGraphicCard : IGraphicCard
    {
        private List<GraphicCard> graphicCards;
        public MockGraphicCard()
        {
            graphicCards = new List<GraphicCard>();
            graphicCards.Add(new GraphicCard{ID = 0, Name="Intel GTX1050"}) ;
            graphicCards.Add(new GraphicCard{ID = 1, Name="Intel GTX1070"}) ;
            graphicCards.Add(new GraphicCard{ID = 2, Name="Intel GTX1080"}) ;
            graphicCards.Add(new GraphicCard{ID = 3, Name="Intel GTX2050"}) ;
            graphicCards.Add(new GraphicCard{ID = 4, Name="Intel GTX2080"}) ;
        }
        public List<Model.GraphicCard> GraphicCards()
        {
            return graphicCards;
        }
    }
}
