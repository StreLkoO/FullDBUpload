using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ЦАД2.Objects;
using ЦАД2.Objects.z_sl;
using ЦАД2.Objects.zap;
using ЦАД2.Objects.zap.sl;
using ЦАД2.Objects.zap.sl.onksl;
using ЦАД2.Objects.zap.sl.ONKSL;
using ЦАД2.Objects.zap.SL;
using ЦАД2.Objects.zap.SL.ONKSL;

namespace ЦАД2
{
    public class MainFileSerializer
    {
        private string ConString;
        private static MainFileSerializer? instance;

        private MainFileSerializer(string conString)
        {
            ConString = conString;
        }

        public static MainFileSerializer Get(string ConString)
        {
            if (instance == null)
            {
                instance = new MainFileSerializer(ConString);
            }
            else
            {
                instance.ConString = ConString;
            }
            return instance;
        }

        public void SerializeWithMap(ViewFile view, string year, string month, string fileDate)
        {
            OracleReader or = OracleReader.Get(ConString);
            Dictionary<string, List<SCHET>> scheta = new();
            Dictionary<string, List<ZAP>> zaps = new();
            Dictionary<string, List<SL>> sl = new();
            Dictionary<string, List<USL>> usl = new();
            Dictionary<string, List<SANK>> sank = new();
            Dictionary<string, List<DS2_N>> ds2_n = new();
            Dictionary<string, List<KSG_KPG>> ksg_kpg = new();
            Dictionary<string, List<LEK_PR_COVID>> lek_pr_covid = new();
            Dictionary<string, List<SL_KOEF>> sl_koef = new();
            Dictionary<string, List<NAZ>> naz = new();
            Dictionary<string, List<MED_DEV>> med_dev = new();
            Task.Run(() => or.QueryData(scheta, "д2_счет.txt", view, year, month));
            Task.Run(() => or.QueryData(zaps, "д2_зак_случай.txt", view, year, month));
            Task.Run(() => or.QueryData(sl, "д2_случай.txt", view, year, month));
            or.QueryData(usl, "д2_услуга.txt", view, year, month);
            or.QueryData(sank, "д2_санк.txt", view, year, month);
            or.QueryData(ds2_n, "д2_доп_дз.txt", view, year, month);

            if (view.TypeFile == TypeFile.ONK || view.TypeFile == TypeFile.Else)
            {
                or.QueryData(ksg_kpg, "д2_ксг_кпг.txt", view, year, month);
                or.QueryData(sl_koef, "д2_сл_коеф.txt", view, year, month);
            }


            if (view.TypeFile == TypeFile.Else)
            {
                or.QueryData(med_dev, "д2_мед_дев.txt", view, year, month);
                or.QueryData(lek_pr_covid, "д2_лек_пр_ковид.txt", view, year, month);
            }

            if (view.TypeFile == TypeFile.DVN)
                or.QueryData(naz, "д2_назн.txt", view, year, month);

            Dictionary<string, List<MR_USL_N>> mr_usl_n = new();
            or.QueryData(mr_usl_n, "д2_мр_усл.txt", view, year, month);
            Dictionary<string, List<ONK_SL>> onk_sl = new();
            Dictionary<string, List<NAPR>> napr = new();
            Dictionary<string, List<CONS>> cons = new();
            Dictionary<string, List<B_DIAG>> b_diag = new();
            Dictionary<string, List<B_PROT>> b_prot = new();
            Dictionary<string, List<ONK_USL>> onk_usl = new();
            Dictionary<string, List<LEK_PR>> lek_pr = new();
            if (view.TypeFile == TypeFile.ONK)
            {
                or.QueryData(onk_sl, "д2_онк_случай.txt", view, year, month);
                or.QueryData(napr, "д2_напр.txt", view, year, month);
                or.QueryData(cons, "д2_конс.txt", view, year, month);
                or.QueryData(b_diag, "д2_диаг.txt", view, year, month);
                or.QueryData(b_prot, "д2_прот.txt", view, year, month);
                or.QueryData(onk_usl, "д2_онк_усл.txt", view, year, month);
                or.QueryData(lek_pr, "д2_лек_пр.txt", view, year, month);
            }



            XmlSerializer xmlSerializer = new(typeof(ZL_LIST));
            foreach (var schet_n in scheta)
            {
                List<ZAP> zap = zaps[schet_n.Key];
                foreach (ZAP z in zap)
                {
                    List<SANK> SankOnZsl = sank.ContainsKey(z.Z_SL.IDCASE) ? sank[z.Z_SL.IDCASE] : new();
                    z.Z_SL.SANK.AddRange(SankOnZsl);
                    double sum = 0;
                    foreach (SANK s in SankOnZsl)
                    {
                        sum += double.Parse(s.S_SUM.Replace(".", ","));
                    }
                    z.Z_SL.SANK_IT = sum.ToString().Replace(",", ".");
                    List<SL> slOnZsl = sl[z.Z_SL.IDCASE];
                    foreach (SL s in slOnZsl)
                    {
                        List<DS2_N> ds2InSl = ds2_n.ContainsKey(s.SL_ID) ? ds2_n[s.SL_ID] : new();
                        if (view.TypeFile == TypeFile.DVN)
                        {

                            s.DS2_N.AddRange(ds2InSl);
                            List<NAZ> nazInSl = naz.ContainsKey(s.SL_ID) ? naz[s.SL_ID] : new();
                            s.NAZ.AddRange(nazInSl);
                        }
                        else
                        {
                            if (ds2InSl.Count > 0)
                            {
                                s.DS2 = new();
                                foreach (DS2_N d in ds2InSl)
                                {
                                    s.DS2!.Add(d.DS2);
                                }
                            }
                        }
                        if (view.TypeFile == TypeFile.Else)
                        {
                            List<LEK_PR_COVID> LekCovidInSl = lek_pr_covid.ContainsKey(s.SL_ID) ? lek_pr_covid[s.SL_ID] : new();
                            s.LEK_PR.AddRange(LekCovidInSl);
                        }
                        if (view.TypeFile == TypeFile.ONK || view.TypeFile == TypeFile.VMP)
                        {
                            List<NAPR> naprInSl = napr.ContainsKey(s.SL_ID) ? napr[s.SL_ID] : new();
                            s.NAPR.AddRange(naprInSl);
                            List<CONS> consInSl = cons.ContainsKey(s.SL_ID) ? cons[s.SL_ID] : new();
                            s.CONS.AddRange(consInSl);
                            if (s.DS_ONK != "1")
                            {
                                List<ONK_SL> onkInSl = onk_sl.ContainsKey(s.SL_ID) ? onk_sl[s.SL_ID] : new();
                                foreach (ONK_SL osl in onkInSl)
                                {
                                    List<B_DIAG> diagInSL = b_diag.ContainsKey(s.SL_ID) ? b_diag[s.SL_ID] : new();
                                    osl.B_DIAG.AddRange(diagInSL);
                                    List<B_PROT> ProtInSL = b_prot.ContainsKey(s.SL_ID) ? b_prot[s.SL_ID] : new();
                                    osl.B_PROT.AddRange(ProtInSL);
                                    List<ONK_USL> onkUslInSL = onk_usl.ContainsKey(s.SL_ID) ? onk_usl[s.SL_ID] : new();
                                    foreach (ONK_USL oNK_USL in onkUslInSL)
                                    {
                                        List<LEK_PR> lekPrInSL = lek_pr.ContainsKey(s.SL_ID) ? lek_pr[s.SL_ID] : new();
                                        oNK_USL.LEK_PR.AddRange(lekPrInSL);
                                        osl.ONK_USL.Add(oNK_USL);
                                    }
                                    s.ONK_SL.Add(osl);
                                }
                            }
                        }
                        if (view.TypeFile != TypeFile.DVN && view.TypeFile != TypeFile.VMP)
                        {
                            List<KSG_KPG> ksgInSL = ksg_kpg.ContainsKey(s.SL_ID) ? ksg_kpg[s.SL_ID] : new();
                            foreach (KSG_KPG ksg in ksgInSL)
                            {
                                if (ksg.SL_KOEF == null)
                                {
                                    List<SL_KOEF> slKoefInSL = sl_koef.ContainsKey(s.SL_ID) ? sl_koef[s.SL_ID] : new();
                                    if (slKoefInSL.Count > 0)
                                    {
                                        ksg.SL_KOEF = new();
                                        ksg.SL_KOEF.AddRange(slKoefInSL);
                                    }

                                }
                                s.KSG_KPG.Add(ksg);
                            }

                        }
                        List<USL> uslInSL = usl[s.SL_ID];
                        foreach (USL uSL in uslInSL)
                        {
                            List<MED_DEV> medDevInUsl = med_dev.ContainsKey(uSL.IDSERV) ? med_dev[uSL.IDSERV] : new();
                            if (medDevInUsl.Count > 0)
                            {
                                uSL.MED_DEV = new();
                                uSL.MED_DEV.AddRange(medDevInUsl);
                            }
                            List<MR_USL_N> mrInUsl = mr_usl_n.ContainsKey(uSL.IDSERV) ? mr_usl_n[uSL.IDSERV] : new();
                            if (view.TypeFile == TypeFile.DVN || view.TypeFile == TypeFile.Else)
                            {
                                uSL.MR_USL_N = new();
                                uSL.MR_USL_N.AddRange(mrInUsl);
                            }
                            else
                            {
                                uSL.PRVS = mrInUsl[0].PRVS;
                                uSL.CODE_MD = mrInUsl[0].CODE_MD;
                            }
                            s.USL.Add(uSL);

                        }
                        z.Z_SL.SL.Add(s);
                    }
                }

                ZL_LIST zL = new(new ZGLV(view.Version, fileDate, schet_n.Key, zap.Count), schet_n.Value.First(), zap);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using XmlTextWriter tw = new(Directory.GetCurrentDirectory() + "\\new folder\\" + schet_n.Key + ".xml", Encoding.GetEncoding(1251));
                XmlSerializerNamespaces xsn = new();
                xsn.Add(String.Empty, String.Empty);
                xmlSerializer.Serialize(tw, zL, xsn);

            }
        }


    }
}
