using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiresShop
{
    class Product
    {
        static Collection<Product> products = new();
        string? _description, _imagePath, _title;
        uint _id, _articleNum, _prodPersonCount, _prodWorkshopNum;
        decimal _minCost;

        public uint Id 
        { 
            get => _id; 
            set
            {
                if (value < 0)
                    return;
                _id = value;
            }
        }
        public string Title { get => _title; set => _title = value; }
        public uint ArticleNum
        {
            get => _articleNum;
            set
            {
                if (value < 0)
                    return;
                _articleNum = value;
            }
        }
        public string Description { get => _description; set => _description = value; }
        public string Image { get => _imagePath; set => _imagePath = value; }
        public uint ProductionPersonCount
        {
            get => _prodPersonCount;
            set
            {
                if (value < 0)
                    return;
                _prodPersonCount = value;
            }
        }
        public uint ProductionWorkshopNumber
        {
            get => _prodWorkshopNum;
            set
            {
                if (value < 0)
                    return;
                _prodWorkshopNum = value;
            }
        }
        public decimal MinCostForAgent
        {
            get => _minCost;
            set
            {
                if (value <= 0)
                    return;
                _minCost = value;
            }
        }

        public static Collection<Product> GetProducts()
        {
            foreach(DataRow i in DBContext.GetProductTable().Rows)
            {
                products.Add(new Product()
                {
                    Id = Convert.ToUInt32(i[0].ToString()),
                    Title = i[1].ToString(),
                    ArticleNum = Convert.ToUInt32(i[3].ToString()),
                    Description = i[4].ToString(),
                    Image = i[5].ToString(),
                    ProductionPersonCount = Convert.ToUInt32(i[6].ToString()),
                    ProductionWorkshopNumber = Convert.ToUInt32(i[7].ToString()),
                    MinCostForAgent = Convert.ToDecimal(i[8].ToString())
                });
            }
            return products;
        }
    }
}
