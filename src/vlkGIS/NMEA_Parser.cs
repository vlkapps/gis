using System;
using System.Globalization;

namespace vlkGIS
{
    class NMEAparser
    {
        // Переменные
        #region
        public readonly string type = ""; // Тип сообщения

        private readonly string msg = ""; // Исходное сообщение

        // $GPRMC - Данные о местоположении
        private readonly string rmc_time = ""; // Время фиксации местоположения
        private readonly string rmc_latitude = ""; // Широта
        private readonly string rmc_latitude_c = ""; // Север/Юг (N/S)
        private readonly string rmc_longitude = ""; // Долгота
        private readonly string rmc_longitude_c = ""; // Запад/Восток (E/W)
        private readonly string rmc_speed = ""; // Скорость в узлах
        private readonly string rmc_heading = ""; // Путевой угол (направление скорости) в градусах
        private readonly string rmc_date = ""; // Дата
        private readonly string rmc_mag = ""; // Магнитное склонение
        private readonly string rmc_route = ""; // Направление

        // $GPGSV - Кол-во видимых спутников
        private readonly string gsv_number_len = ""; // Число сообщений (1-9)
        private readonly string gsv_number_msg = ""; // Номер сообщения (1-9)
        private readonly string gsv_number_sat = ""; // Число видимых спутников
        private readonly string[] gsv_prn; // PRN номер спутника
        private readonly string[] gsv_height; // Высота в градусах
        private readonly string[] gsv_azim; // Азимут
        private readonly string[] gsv_noise; // Отношение сигнал/шум в дБ

        // $GPGSA - Режим работы GPS
        private readonly string gsa_type_1 = "";
        private readonly string gsa_type_2 = "";
        private readonly string[] gsa_prn;
        private readonly string gsa_pdop;
        private readonly string gsa_hdop;
        private readonly string gsa_vdop;

        // $GPGGA - Данные о местоположении
        private readonly string gga_time = ""; // Время (UTC)
        private readonly string gga_lat = ""; // Широта
        private readonly string gga_lat_c = ""; // Север/Юг (N/S)
        private readonly string gga_long = ""; // Долгота
        private readonly string gga_long_c = ""; // Запад/Восток (E/W)
        private readonly string gga_status = ""; // Индикатор качества GPS сигнала
                                                 // 0 = Определение местоположения не возможно или не верно
                                                 // 1 = GPS режим обычной точности
                                                 // 2 = Дифференциальный GPS режим, точность обычная, возможно определение местоположения
                                                 // 3 = GPS режим прецизионной точности
        private readonly string gga_sat_used = ""; // Количество используемых спутников
        private readonly string gga_hdop = ""; // Фактор Ухудшения Точности Плановых Координат (HDOP)
        private readonly string gga_height = ""; // Высота антенны приёмника над/ниже уровня моря
        private readonly string gga_height_unit = ""; // Единица измерения высоты расположения антенны, метры
        private readonly string gga_geo_diff = ""; // Геоидальное различие
        private readonly string gga_unit_diff = ""; // Единица измерения различия, метры
        private readonly string gga_diff_age = ""; // Возраст Дифференциальных данных GPS
        private readonly string gga_id_station = ""; // Индификатор станции, передающей дифференциальные поправки
        #endregion

        public NMEAparser(string str)
        {
            msg = str;
            string[] elements = str.Split(',');

                type = elements[0];

                // Данные о местоположении
                if (type.EndsWith("RMC"))
                {
                    rmc_time = elements[1]; // 1. Время фиксации местоположения UTC
                    rmc_latitude = elements[3]; // 3,4. Географическая широта местоположения, Север/Юг
                    rmc_latitude_c = elements[4]; // 3,4. Географическая широта местоположения, Север/Юг
                    rmc_longitude = elements[5]; // 5,6. Географическая долгота местоположения, Запад/Восток (E/W)
                    rmc_longitude_c = elements[6]; // 5,6. Географическая долгота местоположения, Запад/Восток (E/W)
                    rmc_speed = elements[7]; // 7. Скорость над поверхностью (SOG) в узлах
                    rmc_heading = elements[8]; // 8. Истинное направление курса в градусах
                    rmc_date = elements[9]; // 9. Дата: dd/mm/yy
                    rmc_mag = elements[10]; // 10. Магнитное склонение в градусах
                    rmc_route = elements[11]; // 11. Запад/Восток (E/W)
                }

                // Спутники в данной зоне
                else if (type.EndsWith("GSV"))
                {
                    // $GPGSV, x, x, xx, xx, xx, xxx, xx..........., xx, xx, xxx, xx*hh <CR><LF>
                    gsv_number_len = elements[1]; // 1. Полное число сообщений, от 1 до 9.
                    gsv_number_msg = elements[2]; // 2. Номер сообщения, от 1 до 9.
                    gsv_number_sat = elements[3]; // 3. Полное число видимых спутников.

                    try
                    {
                        // 4, 8, 12, 16. PRN номер спутника.
                        gsv_prn = new string[] { elements[4], elements[4 + 4], elements[4 + 8], elements[4 + 12] };
                        // 5, 9, 13, 17. Высота, градусы, (90° - максимум).
                        gsv_height = new string[] { elements[5], elements[5 + 4], elements[5 + 8], elements[5 + 12] };
                        // 6, 10, 14, 18. Азимут истинный, градусы, от 000° до 359°.
                        gsv_azim = new string[] { elements[6], elements[6 + 4], elements[6 + 8], elements[6 + 12] };
                        // 7, 11, 15, 19. Отношение сигнал/шум от 00 до 99 дБ, ноль - когда нет сигнала.
                        gsv_noise = new string[] { elements[7], elements[7 + 4], elements[7 + 8], elements[7 + 12] };
                        if (gsv_noise[3].Contains("*"))
                            gsv_noise[3] = "";
                    } 
                    catch (Exception) {}
                }

                // Режим работы GPS
                else if (type.EndsWith("GSA"))
                {
                    // $GPGSA, a, x, xx, xx, xx, xx, xx, xx, xx, xx, xx, xx, xx, xx, x.x, x.x, x.x*hh <CR><LF>
                    gsa_type_1 = elements[1]; // 1. Режим: M = Ручной, принудительно включен 2D или 3D режим, A = Автоматический, разрешено автомат. выбирать 2D/3D.
                    gsa_type_2 = elements[2]; // 2. Режим: 1 = Местоположение не определено, 2 = 2D, 3 = 3D
                    // 3-14. PRN номера спутников, использованных при решении задачи местоопределения (нули для неиспользованных).
                    gsa_prn = new string[] { elements[3], elements[4], elements[5], elements[6], elements[7], elements[8], elements[9], elements[10], elements[11], elements[12], elements[13], elements[14] };
                    gsa_pdop = elements[15];
                    gsa_hdop = elements[16];
                    gsa_vdop = elements[17];
                }

                // Исправленные данные
                else if (type.EndsWith("GGA"))
                {
                    // $GPGGA, hhmmss.ss, 1111.11, a, yyyyy.yy, a, x, xx, x.x, xxx, M, x.x, M, x.x, xxxx* hh
                    gga_time = elements[1]; // 1. Гринвичское время на момент определения местоположения.
                    gga_lat = elements[2]; // 2. Географическая широта местоположения.
                    gga_lat_c = elements[3]; // 3. Север / Юг(N / S).
                    gga_long = elements[4]; // 4. Географическая долгота местоположения.
                    gga_long_c = elements[5]; // 5. Запад / Восток(E / W).
                    gga_status = elements[6]; // 6. Индикатор качества GPS сигнала:
                                              // 0 = Определение местоположения не возможно или не верно;
                                              // 1 = GPS режим обычной точности, возможно определение местоположения;
                                              // 2 = Дифференциальный GPS режим, точность обычная, возможно определение местоположения;
                                              // 3 = GPS режим прецизионной точности, возможно определение местоположения.
                    gga_sat_used = elements[7]; // 7. Количество используемых спутников(00 - 12, может отличаться от числа видимых).
                    gga_hdop = elements[8]; // 8. Фактор Ухудшения Точности Плановых Координат(HDOP).
                    gga_height = elements[9]; // 9. Высота антенны приёмника над / ниже уровня моря.
                    gga_height_unit = elements[10]; // 10. Единица измерения высоты расположения антенны, метры.
                    gga_geo_diff = elements[11]; // 11. Геоидальное различие - различие между земным эллипсоидом WGS-84 и уровнем моря(геоидом), ”-” = уровень моря ниже эллипсоида.
                    gga_unit_diff = elements[12]; // 12. Единица измерения различия, метры.
                    gga_diff_age = elements[13]; // 13. Возраст Дифференциальных данных GPS - Время в секундах с момента последнего SC104 типа 1 или 9 обновления, заполнено нулями, если дифференциальный режим не используется.
                    gga_id_station = elements[14]; // 14. Индификатор станции, передающей дифференциальные поправки, ID, 0000 - 1023.
                }
            
        }

        public string Get_RMC()
        {
            return Form1.lang.getString("time") + ":\r\n" + Get_RMC_Time() + "\r\n" + "\r\n" +
                        Form1.lang.getString("lat") + ":\r\n" + Get_RMC_Latitude_Deg().ToString().Replace("-1", "-") + "° " + Get_RMC_Latitude_Minute() + "' " + Math.Round(Get_RMC_Latitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + Get_RMC_Latitude_c_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("lng") + ":\r\n" + Get_RMC_Longitude_Deg().ToString().Replace("-1", "-") + "° " + Get_RMC_Longitude_Minute() + "' " + Math.Round(Get_RMC_Longitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + Get_RMC_Longitude_c_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("speed") + ":\r\n" + Get_RMC_Speed().ToString().Replace("-1", "-") + " " + Form1.lang.getString("knot") + "\r\n" + "\r\n" +
                        Form1.lang.getString("tr_angle") + ":\r\n" + Get_RMC_Heading().ToString().Replace("-1", "-") + "°" + "\r\n" + "\r\n" +
                        Form1.lang.getString("date") + ":\r\n" + Get_RMC_Date() + "\r\n" + "\r\n" +
                        Form1.lang.getString("magnetic") + ":\r\n" + Get_RMC_MagDec().ToString().Replace("-1", "-") + "°" + "\r\n" + "\r\n" +
                        Form1.lang.getString("direction") + ":\r\n" + Get_RMC_Route_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("orig_msg") + ":\r\n" + msg;
        }

        public string Get_GSV()
        {
            return Form1.lang.getString("num_of_msg") + ":\r\n" + Get_GSV_Number_Len() + "\r\n" + "\r\n" +
                        Form1.lang.getString("num_msg") + ":\r\n" + Get_GSV_Number_Msg() + "\r\n" + "\r\n" +
                        Form1.lang.getString("num_visible_sat") + ":\r\n" + Get_GSV_Number_Sat() + "\r\n" + "\r\n" +
                        Form1.lang.getString("prn") + ":\r\n" + Get_GSV_Prn() + "\r\n" + "\r\n" +
                        Form1.lang.getString("height") + ":\r\n" + Get_GSV_Height() + "\r\n" + "\r\n" +
                        Form1.lang.getString("azim") + ":\r\n" + Get_GSV_Azim() + "\r\n" + "\r\n" +
                        Form1.lang.getString("signal_noise") + ":\r\n" + Get_GSV_Noise() + "\r\n" + "\r\n" +
                        Form1.lang.getString("orig_msg") + ":\r\n" + msg;
        }

        public string Get_GSA()
        {
            return Form1.lang.getString("mode") + ":\r\n" + Get_GSA_Type_1() + "\r\n" + "\r\n" +
                        Form1.lang.getString("mode") + ":\r\n" + Get_GSA_Type_2() + "\r\n" + "\r\n" +
                        Form1.lang.getString("satellites") + ":\r\n" + Get_GSA_Prn() + "\r\n" + "\r\n" +
                        Form1.lang.getString("pdop") + ":\r\n" + Get_GSA_PDOP().ToString().Replace("-1", "-") + "\r\n" + "\r\n" +
                        Form1.lang.getString("hdop") + ":\r\n" + Get_GSA_HDOP().ToString().Replace("-1", "-") + "\r\n" + "\r\n" +
                        Form1.lang.getString("vdop") + ":\r\n" + Get_GSA_VDOP().ToString().Replace("-1", "-") + "\r\n" + "\r\n" +
                        Form1.lang.getString("orig_msg") + ":\r\n" + msg;
        }

        public string Get_GGA()
        {
            return Form1.lang.getString("time") + ":\r\n" + Get_GGA_Time() + "\r\n" + "\r\n" +
                        Form1.lang.getString("lat") + ":\r\n" + Get_GGA_Latitude_Deg().ToString().Replace("-1", "-") + "° " + Get_GGA_Latitude_Minute() + "' " + Math.Round(Get_GGA_Latitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + Get_GGA_Latitude_c_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("lng") + ":\r\n" + Get_GGA_Longitude_Deg().ToString().Replace("-1", "-") + "° " + Get_GGA_Longitude_Minute() + "' " + Math.Round(Get_GGA_Longitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + Get_GGA_Longitude_c_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("status") + ":\r\n" + Get_GGA_Status_text() + "\r\n" + "\r\n" +
                        Form1.lang.getString("num_sat") + ":\r\n" + Get_GGA_Sat_Used() + "\r\n" + "\r\n" +
                        Form1.lang.getString("hdop") + ":\r\n" + Get_GGA_HDOP().ToString().Replace("-1", "-") + "\r\n" + "\r\n" +
                        Form1.lang.getString("antenna_height") + ":\r\n" + Get_GGA_Height().ToString().Replace("-1", "-") + " " + Get_GGA_Height_Unit() + "\r\n" + "\r\n" +
                        Form1.lang.getString("geo_diff") + ":\r\n" + Get_GGA_Geo_Diff().ToString().Replace("-1", "-") + " " + Get_GGA_Geo_Diff_Unit() + "\r\n" + "\r\n" +
                        Form1.lang.getString("age_diff") + ":\r\n" + Get_GGA_Diff_Age().ToString().Replace("-1", "-") + "\r\n" + "\r\n" +
                        Form1.lang.getString("orig_msg") + ":\r\n" + msg;
        }


        /////////////////////////////////
        ////////////// RMC //////////////
        /////////////////////////////////
        
        #region
        // Получить часы
        public int Get_RMC_Time_Hour()
        {
            if (rmc_time != "")
                return int.Parse(rmc_time.Substring(0, 2));
            else
                return -1;
        }

        // Получить минуты
        public int Get_RMC_Time_Min()
        {
            if (rmc_time != "")
                return int.Parse(rmc_time.Substring(2, 2));
            else
                return -1;
        }

        // Получить секунды
        public int Get_RMC_Time_Sec()
        {
            if(rmc_time != "")
                return int.Parse(rmc_time.Substring(4, 2));
            else
                return -1;
        }

        // Получить время по формату HH:MM:SS
        public string Get_RMC_Time()
        {
            if (rmc_time != "")
                return DateTime.Parse(Get_RMC_Time_Hour() + ":" + Get_RMC_Time_Min() + ":" + Get_RMC_Time_Sec()).ToLongTimeString();
            else
                return "--:--:--";
        }

        // Получить широту в градусах
        public int Get_RMC_Latitude_Deg()
        {
            if (rmc_latitude != "")
                return int.Parse(rmc_latitude.Substring(0, 2));
            else
                return -1;
        }

        // Получить широту в минутах
        public string Get_RMC_Latitude_Minute()
        {
            if (rmc_latitude != "")
                return rmc_latitude.Substring(2, 2);
            else
                return "-";
        }

        // Получить широту в секундах
        public double Get_RMC_Latitude_Sec()
        {
            if (rmc_latitude != "")
            {
                double c = double.Parse(rmc_latitude, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return a * 100 * 60;
            }
            else
                return -1;
        }

        // Получить широту в десятичном формате
        public double Get_RMC_Latitude_Decimal()
        {
            if (rmc_latitude != "")
            {
                double c = double.Parse(rmc_latitude, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return (int)c / 100 + a * 100 / 60;
            }
            else
                return -1;
        }

        // Получить направление широты
        public string Get_RMC_Latitude_c()
        {
            return rmc_latitude_c;
        }

        // Получить направление широты названием
        public string Get_RMC_Latitude_c_text()
        {
            if (Get_RMC_Latitude_c() == "N")
                return Form1.lang.getString("north");
            else if (Get_RMC_Latitude_c() == "S")
                return Form1.lang.getString("south");
            else
                return "?";
        }

        // Получить долготу в градусах
        public int Get_RMC_Longitude_Deg()
        {
            if (rmc_longitude != "")
                return int.Parse(rmc_longitude.Substring(0, 3));
            else
                return -1;
        }

        // Получить долготу в минутах
        public string Get_RMC_Longitude_Minute()
        {
            if (rmc_longitude != "")
                return rmc_longitude.Substring(3, 2).ToString();
            else
                return "-";
        }

        // Получить долготу в секундах
        public double Get_RMC_Longitude_Sec()
        {
            if (rmc_longitude != "")
            {
                double c = double.Parse(rmc_longitude, CultureInfo.InvariantCulture);
                double a = c - (int)c;
                return a * 60;
            }
            else
                return -1;
        }

        // Получить широту в десятичном формате
        public double Get_RMC_Longitude_Decimal()
        {
            if (rmc_latitude != "")
            {
                double c = double.Parse(rmc_longitude, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return (int)c / 100 + a * 100 / 60;
            }
            else
                return -1;
        }

        // Получить направление долготы
        public string Get_RMC_Longitude_c()
        {
            return rmc_longitude_c;
        }

        // Получить направление долготы названием
        public string Get_RMC_Longitude_c_text()
        {
            if (Get_RMC_Longitude_c() == "E")
                return Form1.lang.getString("east");
            else if (Get_RMC_Longitude_c() == "W")
                return Form1.lang.getString("west");
            else
                return "?";
        }

        // Получить скорость в узлах
        public double Get_RMC_Speed()
        {
            if (rmc_speed != "")
                return double.Parse(rmc_speed, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        // Получить скорость текстом в км/ч
        public string Get_RMC_Speed_Text()
        {
            if (Get_RMC_Speed() > -1)
                return (Get_RMC_Speed() * 1.852) + " " + Form1.lang.getString("kmh");
            else
                return "--- " + Form1.lang.getString("kmh");
        }

        // Получить путевой угол
        public double Get_RMC_Heading()
        {
            if (rmc_heading != "")
                return double.Parse(rmc_heading, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        // Получить день
        public int Get_RMC_Date_Day()
        {
            if (rmc_date != "")
                return int.Parse(rmc_date.Substring(0, 2));
            else
                return -1;
        }

        // Получить месяц
        public int Get_RMC_Date_Mouth()
        {
            if (rmc_date != "")
                return int.Parse(rmc_date.Substring(2, 2));
            else
                return -1;
        }

        // Получить год
        public int Get_RMC_Date_Year()
        {
            if (rmc_date != "")
                return int.Parse(rmc_date.Substring(4, 2));
            else
                return -1;
        }

        // Получить дату
        public string Get_RMC_Date()
        {
            if (rmc_date != "")
                return DateTime.Parse(Get_RMC_Date_Day() + "." + Get_RMC_Date_Mouth() + ".20" + Get_RMC_Date_Year()).ToLongDateString();
            else
                return "--.--.----";
        }

        // Получить магнитное склонение
        public double Get_RMC_MagDec()
        {
            if (rmc_mag != "")
                return double.Parse(rmc_mag, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        // Получить направление
        public string Get_RMC_Route_text()
        {
            if (rmc_route == "E")
                return Form1.lang.getString("east_");
            else if (rmc_route == "W")
                return Form1.lang.getString("west_");
            else
                return "?";
        }
        #endregion

        /////////////////////////////////
        ////////////// GSV //////////////
        /////////////////////////////////

        #region
        public int Get_GSV_Number_Len()
        {
            if (gsv_number_len != "")
                return int.Parse(gsv_number_len);
            else
                return -1;
        }

        public int Get_GSV_Number_Msg()
        {
            if (gsv_number_msg != "")
                return int.Parse(gsv_number_msg);
            else
                return -1;
        }

        public int Get_GSV_Number_Sat()
        {
            if (gsv_number_sat != "")
            {
                if (gsv_number_sat.Contains("*"))
                {
                    return int.Parse(gsv_number_sat.Split('*')[0]);
                }
                else
                {
                    return int.Parse(gsv_number_sat);
                }
            }
            else
                return -1;
        }

        public string Get_GSV_Prn()
        {
            if (gsv_prn != null)
            {
                string prn = "";
                for (int i = 0; i < gsv_prn.Length; i++)
                {
                    if (gsv_prn[i] == "")
                        gsv_prn[i] = "-";
                    prn += gsv_prn[i] + ",";
                }

                if (prn != "")
                    return prn.TrimEnd(',');
                else
                    return "-,-,-,-";
            }
            else
                return "-,-,-,-";
        }

        public string Get_GSV_Height()
        {
            if (gsv_height != null)
            {
                string h = "";
                for (int i = 0; i < gsv_height.Length; i++)
                {
                    if (gsv_height[i] == "")
                        gsv_height[i] = "-";
                    h += gsv_height[i] + "°,";
                }

                if (h != "")
                    return h.TrimEnd(',');
                else
                    return "-°,-°,-°,-°";
            }
            else
                return "-°,-°,-°,-°";
        }

        public string Get_GSV_Azim()
        {
            if (gsv_azim != null)
            {
                string az = "";
                for (int i = 0; i < gsv_azim.Length; i++)
                {
                    if (gsv_azim[i] == "")
                        gsv_azim[i] = "-";
                    az += gsv_azim[i] + ",";
                }

                if (az != "")
                    return az.TrimEnd(',');
                else
                    return "-,-,-,-";
            }
            else
                return "-,-,-,-";
        }

        public string Get_GSV_Noise()
        {
            if (gsv_noise != null)
            {
                string n = "";
                for (int i = 0; i < gsv_noise.Length; i++)
                {
                    if (gsv_noise[i] == "")
                        gsv_noise[i] = "-";
                    n += gsv_noise[i] + " " + Form1.lang.getString("db") + ",";
                }

                if (n != "")
                    return n.TrimEnd(',');
                else
                    return "- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db");
            }
            else
                return "- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db") + ",- " + Form1.lang.getString("db");
        }
        #endregion

        /////////////////////////////////
        ////////////// GSA //////////////
        /////////////////////////////////

        #region
        public string Get_GSA_Type_1()
        {
            if (gsa_type_1 != "")
            {
                if (gsa_type_1 == "M")
                    return Form1.lang.getString("manual");
                else if (gsa_type_1 == "A")
                    return Form1.lang.getString("auto");
                else
                    return "-";
            }
            else
                return "-";
        }

        public string Get_GSA_Type_2()
        {
            if (gsa_type_2 != "")
            {
                if (gsa_type_2 == "1")
                    return Form1.lang.getString("loc_undef");
                else if (gsa_type_2 == "2")
                    return "2D";
                else if (gsa_type_2 == "3")
                    return "3D";
                else
                    return "-";
            }
            else
                return "-";
        }

        public string Get_GSA_Prn()
        {
            if (gsa_prn != null)
            {
                string prn = "";
                for (int i = 0; i < gsa_prn.Length; i++)
                {
                    if (gsa_prn[i] == "")
                        gsa_prn[i] = "-";
                    prn += gsa_prn[i] + ",";
                }
                
                if (prn != "")
                    return prn.TrimEnd(',');
                else
                    return "-";
            }
            else
                return "-";
        }

        public int Get_GSA_Prn_Num()
        {
            int p = -1;
            if (gsa_prn != null)
            {
                p = 0;
                for (int i = 0; i < gsa_prn.Length; i++)
                {
                    if (gsa_prn[i] != "-")
                        p += 1;
                  
                }
            }
            return p;
        }

        public double Get_GSA_PDOP()
        {
            if (gsa_pdop != "")
                return double.Parse(gsa_pdop, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        public double Get_GSA_HDOP()
        {
            if (gsa_hdop != "")
                return double.Parse(gsa_hdop, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        public double Get_GSA_VDOP()
        {
            if (gsa_vdop != "")
                return double.Parse(gsa_vdop.Split('*')[0], CultureInfo.InvariantCulture);
            else
                return -1;
        }
        #endregion

        /////////////////////////////////
        ////////////// GGA //////////////
        /////////////////////////////////

        #region
        // Получить часы
        public int Get_GGA_Time_Hour()
        {
            if (gga_time != "")
                return int.Parse(gga_time.Substring(0, 2));
            else
                return -1;
        }

        // Получить минуты
        public int Get_GGA_Time_Min()
        {
            if (gga_time != "")
                return int.Parse(gga_time.Substring(2, 2));
            else
                return -1;
        }

        // Получить секунды
        public int Get_GGA_Time_Sec()
        {
            if (gga_time != "")
                return int.Parse(gga_time.Substring(4, 2));
            else
                return -1;
        }

        // Получить время по формату HH:MM:SS
        public string Get_GGA_Time()
        {
            if (gga_time != "")
                return DateTime.Parse(Get_GGA_Time_Hour() + ":" + Get_GGA_Time_Min() + ":" + Get_GGA_Time_Sec()).ToLongTimeString();
            else
                return "--:--:--";
        }

        // Получить широту в градусах
        public int Get_GGA_Latitude_Deg()
        {
            if (gga_lat != "")
                return int.Parse(gga_lat.Substring(0, 2));
            else
                return -1;
        }

        // Получить широту в минутах
        public string Get_GGA_Latitude_Minute()
        {
            if (gga_lat != "")
                return gga_lat.Substring(2, 2).ToString();
            else
                return "-";
        }

        // Получить широту в секундах
        public double Get_GGA_Latitude_Sec()
        {
            if (gga_lat != "")
            {
                double c = double.Parse(gga_lat, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return a * 100 * 60;
            }
            else
                return -1;
        }

        // Получить широту в десятичном формате
        public double Get_GGA_Latitude_Decimal()
        {
            if (gga_lat != "")
            {
                double c = double.Parse(gga_lat, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return (int)c / 100 + a * 100 / 60;
            }
            else
                return -1;
        }

        // Получить направление широты
        public string Get_GGA_Latitude_c()
        {
            return gga_lat_c;
        }

        // Получить направление широты названием
        public string Get_GGA_Latitude_c_text()
        {
            if (Get_GGA_Latitude_c() == "N")
                return Form1.lang.getString("north");
            else if (Get_GGA_Latitude_c() == "S")
                return Form1.lang.getString("south");
            else
                return "?";
        }

        // Получить долготу в градусах
        public int Get_GGA_Longitude_Deg()
        {
            if (gga_long != "")
                return int.Parse(gga_long.Substring(0, 3));
            else
                return -1;
        }

        // Получить долготу в минутах
        public string Get_GGA_Longitude_Minute()
        {
            if (gga_long != "")
                return gga_long.Substring(3, 2).ToString();
            else
                return "-";
        }

        // Получить долготу в секундах
        public double Get_GGA_Longitude_Sec()
        {
            if (gga_long != "")
            {
                double c = double.Parse(gga_long, CultureInfo.InvariantCulture);
                double a = c - (int)c;
                return a * 60;
            }
            else
                return -1;
        }

        // Получить широту в десятичном формате
        public double Get_GGA_Longitude_Decimal()
        {
            if (gga_long != "")
            {
                double c = double.Parse(gga_long, CultureInfo.InvariantCulture);
                double a = c / 100 - (int)c / 100;
                return (int)c / 100 + a * 100 / 60;
            }
            else
                return -1;
        }

        // Получить направление долготы
        public string Get_GGA_Longitude_c()
        {
            return gga_long_c;
        }

        // Получить направление долготы названием
        public string Get_GGA_Longitude_c_text()
        {
            if (Get_GGA_Longitude_c() == "E")
                return Form1.lang.getString("east");
            else if (Get_GGA_Longitude_c() == "W")
                return Form1.lang.getString("west");
            else
                return "?";
        }

        public string Get_GGA_Status_text()
        {
            if (gga_status == "0")
                return Form1.lang.getString("pos_acc_a");
            else if (gga_status == "1")
                return Form1.lang.getString("pos_acc_b");
            else if (gga_status == "2")
                return Form1.lang.getString("pos_acc_c");
            else if (gga_status == "3")
                return Form1.lang.getString("pos_acc_d");
            else
                return "-";
        }

        public int Get_GGA_Sat_Used()
        {
            if (gga_sat_used != "")
                return int.Parse(gga_sat_used);
            else
                return -1;
        }

        public double Get_GGA_HDOP()
        {
            if (gga_hdop != "")
                return double.Parse(gga_hdop, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        public double Get_GGA_Height()
        {
            if (gga_height != "")
                return double.Parse(gga_height, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        public string Get_GGA_Height_Unit()
        {
            if (gga_height_unit == "M")
                return Form1.lang.getString("meter");
            else
                return "?";
        }

        public double Get_GGA_Geo_Diff()
        {
            if (gga_geo_diff != "")
                return double.Parse(gga_geo_diff, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        public string Get_GGA_Geo_Diff_Unit()
        {
            if (gga_unit_diff == "M")
                return Form1.lang.getString("meter");
            else
                return "?";
        }

        public double Get_GGA_Diff_Age()
        {
            if (gga_diff_age != "")
                return double.Parse(gga_diff_age, CultureInfo.InvariantCulture);
            else
                return -1;
        }

        #endregion
    }
}
