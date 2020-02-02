using RomaniaMea.Models;
using RomaniaMea.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMea.API
{
    public static class DBInitializer
    {
        public static async Task InitializeDatabaseAsync(IRepositoryWrapper repositoryWrapper)
        {
            if (repositoryWrapper.Category.GetAllAsync().Result.Count() == 0 ||
                repositoryWrapper.Product.GetAllAsync().Result.Count() == 0)
            {
                var CeramicObjectCategory = new Category
                {
                    Name = "CeramicObject"
                };

                await repositoryWrapper.Category.CreateAsync(CeramicObjectCategory);

                var WoodObjectCategory = new Category
                {
                    Name = "WoodObject"
                };
                
                await repositoryWrapper.Category.CreateAsync(WoodObjectCategory);
                await repositoryWrapper.SaveAsync();

                var ReligionObjectCategory = new Category
                {
                    Name = "ReligionObject"
                };

                await repositoryWrapper.Category.CreateAsync(ReligionObjectCategory);
                await repositoryWrapper.SaveAsync();

                var TraditionalClothesCategory = new Category
                {
                    Name = "TraditionalClothes"
                };

                await repositoryWrapper.Category.CreateAsync(TraditionalClothesCategory);
                await repositoryWrapper.SaveAsync();

                var ToysCategory = new Category
                {
                    Name = "Toys"
                };

                await repositoryWrapper.Category.CreateAsync(ToysCategory);
                await repositoryWrapper.SaveAsync();

                var ceramic1 = new Product
                {
                    Name = "Vază ceramică Aurora",
                    Description = "Vaza din ceramică colorată de Corund este o piesă tradițională de decor, gata să-și găsească un loc de cinste în casa ta.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC1-vaza-de-ceramica-colorata-de-corund-medie-model-2-1.jpg",
                    IsProductOfTheWeek = true,
                    Price = 76
                };

                await repositoryWrapper.Product.CreateAsync(ceramic1);
                await repositoryWrapper.SaveAsync();

                var ceramic2 = new Product
                {
                    Name = "Recipient zahăr Corund",
                    Description = "Recipientul de zahăr din ceramică colorată de Corund reprezintă o modalitate de efect de depozitare a diverselor condimente. Vasul înfrumusețează orice decor,prin crearea unei atmosfere rustice deosebite.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC2-recipient-zahar-ceramica-colorata-corund-model-2-3.jpg",
                    IsProductOfTheWeek = true,
                    Price = 28
                };

                await repositoryWrapper.Product.CreateAsync(ceramic2);
                await repositoryWrapper.SaveAsync();

                var ceramic3 = new Product
                {
                    Name = "Suport șervețele Corund",
                    Description = "Suportul de servețele din ceramică albastră de Corund este un minunat obiect de decor, menit să înfrumusețeze mesele dumneavoastră, indiferent de ocazie.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC3-suport-servetele-ceramica-albastra-corund-2.jpg",
                    IsProductOfTheWeek = true,
                    Price = 24
                };

                await repositoryWrapper.Product.CreateAsync(ceramic3);
                await repositoryWrapper.SaveAsync();

                var ceramic4 = new Product
                {
                    Name = "Ulcior ceramică",
                    Description = "Ulciorul din ceramică colorată de Corund cucerește prin liniile sale perfecte, prin motivele tradiționale realizate cu atâta atenție și prin cromatica deosebită, specifică zonei Corundului.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC4-ulcior-mic-ceramica-colorata-corund-model-1-3_2.jpg",
                    IsProductOfTheWeek = true,
                    Price = 24
                };

                await repositoryWrapper.Product.CreateAsync(ceramic4);
                await repositoryWrapper.SaveAsync();

                var ceramic5 = new Product
                {
                    Name = "Farfurie ceramică",
                    Description = "Farfurie ceramică din zona Maramureșului.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC5-farfurie_ceramica_baia_mare_16_cm_03.jpg",
                    IsProductOfTheWeek = true,
                    Price = 54
                };

                await repositoryWrapper.Product.CreateAsync(ceramic5);
                await repositoryWrapper.SaveAsync();

                var ceramic6 = new Product
                {
                    Name = "Set căni vin",
                    Description = "Setul 6 căni de vin din zona Maramureșului îți poate ține companie la crăpatul zorilor sau la petreceri festive, însă poate fi și un suvenir de mare efect pentru cei ce vor să aibă aproape o părticică din România.",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC6-set-cani-vin-ceramica-rosie-corund-2.jpg",
                    IsProductOfTheWeek = true,
                    Price = 105
                };

                await repositoryWrapper.Product.CreateAsync(ceramic6);
                await repositoryWrapper.SaveAsync();

                var ceramic7 = new Product
                {
                    Name = "Set pentru țuică",
                    Description = "Set pentru tuică din ceramica Bledea Maramureș",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC7-set_tuica_03.jpg",
                    IsProductOfTheWeek = true,
                    Price = 144
                };

                await repositoryWrapper.Product.CreateAsync(ceramic7);
                await repositoryWrapper.SaveAsync();

                var ceramic8 = new Product
                {
                    Name = "Clopoțel ceramică",
                    Description = "Clopoțel ceramică Bledea Maramureș",
                    CategoryId = CeramicObjectCategory.Id,
                    ImageUrl = "/img/OC8-clopotel_ceramica_bledea_06.jpg",
                    IsProductOfTheWeek = true,
                    Price = 124
                };

                await repositoryWrapper.Product.CreateAsync(ceramic8);
                await repositoryWrapper.SaveAsync();

                var religion1 = new Product
                {
                    Name = "Cruce colorată Ioan",
                    Description = "Cruce Ceramica Colorata Ioan",
                    CategoryId = ReligionObjectCategory.Id,
                    ImageUrl = "/img/OR1-cruce-ceramica-colorata-corund-1.jpg",
                    IsProductOfTheWeek = false,
                    Price = 54
                };
                await repositoryWrapper.Product.CreateAsync(religion1);
                await repositoryWrapper.SaveAsync();

                var religion2 = new Product
                {
                    Name = "Cruce colorată Matei",
                    Description = "Cruce Ceramica Colorata Matei",
                    CategoryId = ReligionObjectCategory.Id,
                    ImageUrl = "/img/OR2-cruce-ceramica-colorata-corund-1.jpg",
                    IsProductOfTheWeek = true,
                    Price = 54
                };
                await repositoryWrapper.Product.CreateAsync(religion2);
                await repositoryWrapper.SaveAsync();

                var religion3 = new Product
                {
                    Name = "Cruce colorată Luca",
                    Description = "Cruce Ceramica Colorata Luca",
                    CategoryId = ReligionObjectCategory.Id,
                    ImageUrl = "/img/OR3-cruce-ceramica-colorata-corund-1.jpg",
                    IsProductOfTheWeek = false,
                    Price = 54
                };
                await repositoryWrapper.Product.CreateAsync(religion3);
                await repositoryWrapper.SaveAsync();

                var wood1 = new Product
                {
                    Name = "Lingură Dac",
                    Description = "Lingură sculptată în lemn de maestrul Ion Rodoș - Dac",
                    CategoryId = WoodObjectCategory.Id,
                    ImageUrl = "/img/OL1-lingura_sculptata_din_lemn_maestrul_ion_rodos_dac_03.jpg",
                    IsProductOfTheWeek = false,
                    Price = 148
                };
                await repositoryWrapper.Product.CreateAsync(wood1);
                await repositoryWrapper.SaveAsync();

                var wood2 = new Product
                {
                    Name = "Lingură Floare de Colț",
                    Description = "Lingură sculptată în lemn de maestrul Ion Rodoș - Floare de Colț",
                    CategoryId = WoodObjectCategory.Id,
                    ImageUrl = "/img/OL2-lingura_sculptata_din_lemn_maestrul_ion_rodos_floare_de_colt_03.jpg",
                    IsProductOfTheWeek = true,
                    Price = 148
                };
                await repositoryWrapper.Product.CreateAsync(wood2);
                await repositoryWrapper.SaveAsync();

                var wood3 = new Product
                {
                    Name = "Lingură Pești",
                    Description = "Lingură sculptată în lemn de maestrul Ion Rodoș - Pești",
                    CategoryId = WoodObjectCategory.Id,
                    ImageUrl = "/img/OL4-lingura_sculptata_din_lemn_maestrul_ion_rodos_pesti_03.jpg",
                    IsProductOfTheWeek = false,
                    Price = 148
                };
                await repositoryWrapper.Product.CreateAsync(wood3);
                await repositoryWrapper.SaveAsync();

                var traditional1 = new Product
                {
                    Name = "Ie bej",
                    Description = "Ie Bej cu dantela Maro si maneca trei sferturi. Mărimea este universală!",
                    CategoryId = TraditionalClothesCategory.Id,
                    ImageUrl = "/img/CT1-ie-bej-cu-dantela-maro-cu-maneca-trei-sferturi-model-14-1.jpg",
                    IsProductOfTheWeek = true,
                    Price = 196
                };
                await repositoryWrapper.Product.CreateAsync(traditional1);
                await repositoryWrapper.SaveAsync();

                var traditional2 = new Product
                {
                    Name = "Botoșei copii",
                    Description = "Botoșei din lână pentru copii. Un produs foarte călduros, fiind pentru sezonul rece factor in plus de protecție pentru copilași.",
                    CategoryId = TraditionalClothesCategory.Id,
                    ImageUrl = "/img/CT2-botosei_din_lana_bebelusi_02.jpg",
                    IsProductOfTheWeek = true,
                    Price = 167
                };
                await repositoryWrapper.Product.CreateAsync(traditional2);
                await repositoryWrapper.SaveAsync();

                var traditional3 = new Product
                {
                    Name = "Ie albastră",
                    Description = "Ie Bej cu dantela Maro si maneca trei sferturi. Mărimea este universală!",
                    CategoryId = TraditionalClothesCategory.Id,
                    ImageUrl = "/img/CT3-ie-alba-cu-dantela-albastra-cu-maneca-scurta-model-16-1.jpg",
                    IsProductOfTheWeek = true,
                    Price = 197
                };
                await repositoryWrapper.Product.CreateAsync(traditional3);
                await repositoryWrapper.SaveAsync();

                var traditional4 = new Product
                {
                    Name = "Clopot",
                    Description = "Clop tradițional adulti",
                    CategoryId = TraditionalClothesCategory.Id,
                    ImageUrl = "/img/CT5-clop-traditional-adulti-2.jpg",
                    IsProductOfTheWeek = true,
                    Price = 48
                };
                await repositoryWrapper.Product.CreateAsync(traditional4);
                await repositoryWrapper.SaveAsync();

                var toys1 = new Product
                {
                    Name = "Păpușă pușculiță",
                    Description = "Realizate după chipul și asemănarea țăranului și țărăncuței de odinioară, păpușile tradiționale din ceramică sunt minunate piese de decor ce ne transportă în timpuri demult apuse.",
                    CategoryId = ToysCategory.Id,
                    ImageUrl = "/img/T1-papusa-pusculita-traditionala-ceramica-mica-model-fetita-16-cm-8.jpg",
                    IsProductOfTheWeek = true,
                    Price = 97
                };
                await repositoryWrapper.Product.CreateAsync(toys1);
                await repositoryWrapper.SaveAsync();

                var toys2 = new Product
                {
                    Name = "Păpușă țărăncuță",
                    Description = "Păpușă realizată manual din ceramică în port tradițional românesc (Țărancă).Pe un cadru din ceramică picatată,făcuta in atelierul familie Iacinschi din Maramureș și îmbrăcată cu haine tradiționale autentice din zona Maramureșului, aceste păpuși reprezintă cadoul ideal pentru orice iubitor de artă populară. ",
                    CategoryId = ToysCategory.Id,
                    ImageUrl = "/img/T2-papusa_realizata_manual_din_ceramica_in_port_traditional_romanesc__taranca__03.jpg",
                    IsProductOfTheWeek = true,
                    Price = 72
                };
                await repositoryWrapper.Product.CreateAsync(toys2);
                await repositoryWrapper.SaveAsync();

                var toys3 = new Product
                {
                    Name = "Păpușă țărăn",
                    Description = "Păpușă realizată manual din ceramică în port tradițional românesc (Țăran).Pe un cadru din ceramică picatată,făcuta in atelierul familie Iacinschi din Maramureș și îmbrăcată cu haine tradiționale autentice din zona Maramureșului, aceste păpuși reprezintă cadoul ideal pentru orice iubitor de artă populară. ",
                    CategoryId = ToysCategory.Id,
                    ImageUrl = "/img/T2-papusa_realizata_manual_din_ceramica_in_port_traditional_romanesc__taran__03.jpg",
                    IsProductOfTheWeek = true,
                    Price = 72
                };
                await repositoryWrapper.Product.CreateAsync(toys3);
                await repositoryWrapper.SaveAsync();
            }
        }
    }
}
