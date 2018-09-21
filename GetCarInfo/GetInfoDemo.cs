using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GetCarInfo
{
    public partial class GetInfoDemo : Form
    {
        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;// //报警回调函数
        private Int32 m_lUserID = -1;//登录返回值
        private Int32 iListenHandle = -1;//监听返回值
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        CHCNetSDK.REALDATACALLBACK RealData = null;
        private Int32 m_lRealHandle = -1;
        private Int32 alarmChan = -1;//布防返回值
        public delegate void UpdateListBoxCallback(string strAlarmTime, string strDevIP, string strAlarmMsg);
        CHCNetSDK.NET_VCA_TRAVERSE_PLANE m_struTraversePlane = new CHCNetSDK.NET_VCA_TRAVERSE_PLANE();
        CHCNetSDK.NET_VCA_AREA m_struVcaArea = new CHCNetSDK.NET_VCA_AREA();
        CHCNetSDK.NET_VCA_INTRUSION m_struIntrusion = new CHCNetSDK.NET_VCA_INTRUSION();
        CHCNetSDK.UNION_STATFRAME m_struStatFrame = new CHCNetSDK.UNION_STATFRAME();
        CHCNetSDK.UNION_STATTIME m_struStatTime = new CHCNetSDK.UNION_STATTIME();
        public GetInfoDemo()
        {
            InitializeComponent();
            string str = Application.StartupPath;
            if (!CHCNetSDK.NET_DVR_Init())
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            //设置报警回调函数
            if (m_falarmData_V31 == null)
            {
                m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
            }
            IntPtr pUser = new IntPtr();
            CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, pUser);
            // MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
        }
        public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            AlarmMessageHandle(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
            return true;
        }
        public void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            AlarmMessageHandle(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
        }

        public void ProcessCommAlarm(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_DVR_ALARMINFO struAlarmInfo = new CHCNetSDK.NET_DVR_ALARMINFO();

            struAlarmInfo = (CHCNetSDK.NET_DVR_ALARMINFO)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO));

            string strIP = pAlarmer.sDeviceIP;
            string stringAlarm = "";
            int i = 0;

            switch (struAlarmInfo.dwAlarmType)
            {
                case 0:
                    stringAlarm = "信号量报警，报警报警输入口：" + struAlarmInfo.dwAlarmInputNumber + "，触发录像通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM; i++)
                    {
                        if (struAlarmInfo.dwAlarmRelateChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 1:
                    stringAlarm = "硬盘满，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM; i++)
                    {
                        if (struAlarmInfo.dwDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 2:
                    stringAlarm = "信号丢失，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM; i++)
                    {
                        if (struAlarmInfo.dwChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 3:
                    stringAlarm = "移动侦测，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM; i++)
                    {
                        if (struAlarmInfo.dwChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 4:
                    stringAlarm = "硬盘未格式化，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM; i++)
                    {
                        if (struAlarmInfo.dwDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 5:
                    stringAlarm = "读写硬盘出错，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM; i++)
                    {
                        if (struAlarmInfo.dwDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 6:
                    stringAlarm = "遮挡报警，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM; i++)
                    {
                        if (struAlarmInfo.dwChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 7:
                    stringAlarm = "制式不匹配，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM; i++)
                    {
                        if (struAlarmInfo.dwChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 8:
                    stringAlarm = "非法访问";
                    break;
                default:
                    stringAlarm = "其他未知报警信息";
                    break;
            }
            txtCarInfo.Invoke(new Action(() =>
            {
                txtCarInfo.Text += Environment.NewLine + DateTime.Now.ToString() + "       " + strIP + "            " + stringAlarm;
            }));
        }

        private void ProcessCommAlarm_V30(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {

            CHCNetSDK.NET_DVR_ALARMINFO_V30 struAlarmInfoV30 = new CHCNetSDK.NET_DVR_ALARMINFO_V30();

            struAlarmInfoV30 = (CHCNetSDK.NET_DVR_ALARMINFO_V30)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO_V30));

            string strIP = pAlarmer.sDeviceIP;
            string stringAlarm = "";
            int i;

            switch (struAlarmInfoV30.dwAlarmType)
            {
                case 0:
                    stringAlarm = "信号量报警，报警报警输入口：" + struAlarmInfoV30.dwAlarmInputNumber + "，触发录像通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byAlarmRelateChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + "\\";
                        }
                    }
                    break;
                case 1:
                    stringAlarm = "硬盘满，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " ";
                        }
                    }
                    break;
                case 2:
                    stringAlarm = "信号丢失，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 3:
                    stringAlarm = "移动侦测，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 4:
                    stringAlarm = "硬盘未格式化，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 5:
                    stringAlarm = "读写硬盘出错，报警硬盘号：";
                    for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byDiskNumber[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 6:
                    stringAlarm = "遮挡报警，报警通道：";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 7:
                    stringAlarm = "制式不匹配，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 8:
                    stringAlarm = "非法访问";
                    break;
                case 9:
                    stringAlarm = "视频信号异常，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 10:
                    stringAlarm = "录像/抓图异常，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 11:
                    stringAlarm = "智能场景变化，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 12:
                    stringAlarm = "阵列异常";
                    break;
                case 13:
                    stringAlarm = "前端/录像分辨率不匹配，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                case 15:
                    stringAlarm = "智能侦测，报警通道";
                    for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                    {
                        if (struAlarmInfoV30.byChannel[i] == 1)
                        {
                            stringAlarm += (i + 1) + " \\ ";
                        }
                    }
                    break;
                default:
                    stringAlarm = "其他未知报警信息";
                    break;
            }
            this.Invoke(new Action(() =>
            {
                txtCarInfo.Text += Environment.NewLine + DateTime.Now.ToString() + "       " + strIP + "            " + stringAlarm;
            }));

        }

        private void ProcessCommAlarm_RULE(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_VCA_RULE_ALARM struRuleAlarmInfo = new CHCNetSDK.NET_VCA_RULE_ALARM();
            struRuleAlarmInfo = (CHCNetSDK.NET_VCA_RULE_ALARM)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_VCA_RULE_ALARM));

            //报警信息
            string stringAlarm = "";
            uint dwSize = (uint)Marshal.SizeOf(struRuleAlarmInfo.struRuleInfo.uEventParam);

            switch (struRuleAlarmInfo.struRuleInfo.wEventTypeEx)
            {
                case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_TRAVERSE_PLANE:
                    IntPtr ptrTraverseInfo = Marshal.AllocHGlobal((Int32)dwSize);
                    Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrTraverseInfo, false);
                    m_struTraversePlane = (CHCNetSDK.NET_VCA_TRAVERSE_PLANE)Marshal.PtrToStructure(ptrTraverseInfo, typeof(CHCNetSDK.NET_VCA_TRAVERSE_PLANE));
                    stringAlarm = "穿越警戒面，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                    //警戒面边线起点坐标: (m_struTraversePlane.struPlaneBottom.struStart.fX, m_struTraversePlane.struPlaneBottom.struStart.fY)
                    //警戒面边线终点坐标: (m_struTraversePlane.struPlaneBottom.struEnd.fX, m_struTraversePlane.struPlaneBottom.struEnd.fY)
                    break;
                case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_ENTER_AREA:
                    IntPtr ptrEnterInfo = Marshal.AllocHGlobal((Int32)dwSize);
                    Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrEnterInfo, false);
                    m_struVcaArea = (CHCNetSDK.NET_VCA_AREA)Marshal.PtrToStructure(ptrEnterInfo, typeof(CHCNetSDK.NET_VCA_AREA));
                    stringAlarm = "目标进入区域，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                    //m_struVcaArea.struRegion 多边形区域坐标
                    break;
                case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_EXIT_AREA:
                    IntPtr ptrExitInfo = Marshal.AllocHGlobal((Int32)dwSize);
                    Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrExitInfo, false);
                    m_struVcaArea = (CHCNetSDK.NET_VCA_AREA)Marshal.PtrToStructure(ptrExitInfo, typeof(CHCNetSDK.NET_VCA_AREA));
                    stringAlarm = "目标离开区域，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                    //m_struVcaArea.struRegion 多边形区域坐标
                    break;
                case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_INTRUSION:
                    IntPtr ptrIntrusionInfo = Marshal.AllocHGlobal((Int32)dwSize);
                    Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrIntrusionInfo, false);
                    m_struIntrusion = (CHCNetSDK.NET_VCA_INTRUSION)Marshal.PtrToStructure(ptrIntrusionInfo, typeof(CHCNetSDK.NET_VCA_INTRUSION));

                    int i = 0;
                    string strRegion = "";
                    for (i = 0; i < m_struIntrusion.struRegion.dwPointNum; i++)
                    {
                        strRegion = strRegion + "(" + m_struIntrusion.struRegion.struPos[i].fX + "," + m_struIntrusion.struRegion.struPos[i].fY + ")";
                    }
                    stringAlarm = "周界入侵，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID + "，区域范围：" + strRegion;
                    //m_struIntrusion.struRegion 多边形区域坐标
                    break;
                default:
                    stringAlarm = "其他行为分析报警，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                    break;
            }


            //报警图片保存
            if (struRuleAlarmInfo.dwPicDataLen > 0)
            {
                FileStream fs = new FileStream("行为分析报警抓图.jpg", FileMode.Create);
                int iLen = (int)struRuleAlarmInfo.dwPicDataLen;
                byte[] by = new byte[iLen];
                Marshal.Copy(struRuleAlarmInfo.pImage, by, 0, iLen);
                fs.Write(by, 0, iLen);
                fs.Close();
            }

            //报警时间：年月日时分秒
            string strTimeYear = ((struRuleAlarmInfo.dwAbsTime >> 26) + 2000).ToString();
            string strTimeMonth = ((struRuleAlarmInfo.dwAbsTime >> 22) & 15).ToString("d2");
            string strTimeDay = ((struRuleAlarmInfo.dwAbsTime >> 17) & 31).ToString("d2");
            string strTimeHour = ((struRuleAlarmInfo.dwAbsTime >> 12) & 31).ToString("d2");
            string strTimeMinute = ((struRuleAlarmInfo.dwAbsTime >> 6) & 63).ToString("d2");
            string strTimeSecond = ((struRuleAlarmInfo.dwAbsTime >> 0) & 63).ToString("d2");
            string strTime = strTimeYear + "-" + strTimeMonth + "-" + strTimeDay + " " + strTimeHour + ":" + strTimeMinute + ":" + strTimeSecond;

            //报警设备IP地址
            string strIP = struRuleAlarmInfo.struDevInfo.struDevIP.sIpV4;
        }
        public void AlarmMessageHandle(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            switch (lCommand)
            {
                case CHCNetSDK.COMM_ALARM: //(DS-8000老设备)移动侦测、视频丢失、遮挡、IO信号量等报警信息
                    ProcessCommAlarm(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ALARM_V30://移动侦测、视频丢失、遮挡、IO信号量等报警信息
                    ProcessCommAlarm_V30(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ITS_PLATE_RESULT://交通抓拍结果上传(新报警信息类型)
                    ProcessCommAlarm_ITSPlate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                default:
                    {
                        //报警设备IP地址
                        string strIP = pAlarmer.sDeviceIP;

                        //报警信息类型
                        string stringAlarm = "报警上传，信息类型：" + lCommand;
                    }
                    break;
            }
        }
        private void ProcessCommAlarm_ITSPlate(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult = new CHCNetSDK.NET_ITS_PLATE_RESULT();
            uint dwSize = (uint)Marshal.SizeOf(struITSPlateResult);

            struITSPlateResult = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));

            //保存抓拍图片
            for (int i = 0; i < struITSPlateResult.dwPicNum; i++)
            {
                if (struITSPlateResult.struPicInfo[i].dwDataLen != 0)
                {
                    string str = "ITS_UserID_[" + pAlarmer.lUserID + "]_Pictype_" + struITSPlateResult.struPicInfo[i].byType + "_Num" + (i + 1) + ".jpg";
                    FileStream fs = new FileStream(str, FileMode.Create);
                    int iLen = (int)struITSPlateResult.struPicInfo[i].dwDataLen;
                    byte[] by = new byte[iLen];
                    Marshal.Copy(struITSPlateResult.struPicInfo[i].pBuffer, by, 0, iLen);
                    fs.Write(by, 0, iLen);
                    fs.Close();
                }
            }
            //报警设备IP地址
            string strIP = pAlarmer.sDeviceIP;

            //抓拍时间：年月日时分秒
            string strTimeYear = string.Format("{0:D4}", struITSPlateResult.struSnapFirstPicTime.wYear) +
                string.Format("{0:D2}", struITSPlateResult.struSnapFirstPicTime.byMonth) +
                string.Format("{0:D2}", struITSPlateResult.struSnapFirstPicTime.byDay) + " "
                + string.Format("{0:D2}", struITSPlateResult.struSnapFirstPicTime.byHour) + ":"
                + string.Format("{0:D2}", struITSPlateResult.struSnapFirstPicTime.byMinute) + ":"
                + string.Format("{0:D2}", struITSPlateResult.struSnapFirstPicTime.bySecond) + ":"
                + string.Format("{0:D3}", struITSPlateResult.struSnapFirstPicTime.wMilliSec);

            //上传结果
            string stringPlateLicense = System.Text.Encoding.GetEncoding("GBK").GetString(struITSPlateResult.struPlateInfo.sLicense).TrimEnd('\0');
            string stringAlarm = "抓拍上传，" + "车牌：" + stringPlateLicense + "，车辆序号：" + struITSPlateResult.struVehicleInfo.dwIndex;

            this.Invoke(new Action(() =>
            {
                txtCarInfo.Text += Environment.NewLine + DateTime.Now.ToString() + "       " + strIP + "            " + stringAlarm;
                txtCarNO.Text = stringPlateLicense;
            }));
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtDeIP.Text == "" || txtDePortNum.Text == "" ||
               txtUser.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            string DVRIPAddress = txtDeIP.Text; //设备IP地址或者域名 Device IP
            Int16 DVRPortNumber = Int16.Parse(txtDePortNum.Text);//设备服务端口号 Device Port
            string DVRUserName = txtUser.Text;//设备登录用户名 User name to login
            string DVRPassword = txtPwd.Text;//设备登录密码 Password to login

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                string strErr = "NET_DVR_Login_V30 failed, error code= " + CHCNetSDK.NET_DVR_GetLastError(); //登录失败，输出错误号 Failed to login and output the error code
                MessageBox.Show(strErr);
                return;
            }
            else
            {
                MessageBox.Show("登录成功！");
                btnLogin.Enabled = false;
                btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //注销登录
            CHCNetSDK.NET_DVR_Logout(m_lUserID);

            btnLogin.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void btnListenBegin_Click(object sender, EventArgs e)
        {
            if (m_falarmData == null)
            {
                m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
            }
            iListenHandle = CHCNetSDK.NET_DVR_StartListen_V30(txtIP.Text, Convert.ToUInt16(txtPort.Text), m_falarmData, IntPtr.Zero);
            if (iListenHandle == -1)
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
            else
            {
                MessageBox.Show("监听成功!");
                btnListenBegin.Enabled = false;
                btnListenEnd.Enabled = true;
            }
        }

        private void btnListenEnd_Click(object sender, EventArgs e)
        {
            if (!CHCNetSDK.NET_DVR_StopListen_V30(iListenHandle))
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
            else
            {
                MessageBox.Show("停止监听操作成功!");
                btnListenBegin.Enabled = true;
                btnListenEnd.Enabled = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (m_lUserID < 0)
            {
                MessageBox.Show("Please login the device firstly");
                return;
            }

            if (m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = picView.Handle;//预览窗口
                lpPreviewInfo.lChannel = 36;//预te览的设备通道
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                }

                IntPtr pUser = new IntPtr();//用户数据

                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null, pUser);
                if (m_lRealHandle < 0)
                {
                    string str = "NET_DVR_RealPlay_V40 failed, error code= " + CHCNetSDK.NET_DVR_GetLastError(); //预览失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
            }
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_JPEGPARA lpPreviewInfo = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpPreviewInfo.wPicQuality = 0;
            lpPreviewInfo.wPicSize = 0xff;

            if (File.Exists(@"C:\Users\EMEWE\Desktop\1.jpg"))
            {
                File.Delete(@"C:\Users\EMEWE\Desktop\1.jpg");
            }

            if (CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, 36, ref lpPreviewInfo, @"C:\Users\EMEWE\Desktop\1.jpg"))
            {
                picImg.Image = Image.FromFile(@"C:\Users\EMEWE\Desktop\1.jpg");
            }
            else
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
        }

        private void btnAlarmChanB_Click(object sender, EventArgs e)
        {
            CHCNetSDK.NET_DVR_SETUPALARM_PARAM nET_DVR_SETUPALARM_PARAM = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
            alarmChan = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref nET_DVR_SETUPALARM_PARAM);
            if (alarmChan == -1)
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
            else
            {
                MessageBox.Show("布防成功!");
                btnAlarmChanB.Enabled = false;
                btnAlarmChanEnd.Enabled = true;
            }
        }

        private void btnAlarmChanEnd_Click(object sender, EventArgs e)
        {
            if (!CHCNetSDK.NET_DVR_CloseAlarmChan_V30(alarmChan))
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
            else
            {
                MessageBox.Show("撤防成功!");
                btnAlarmChanB.Enabled = true;
                btnAlarmChanEnd.Enabled = false;
            }
        }

        private void GetInfoDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //释放SDK资源，在程序结束之前调用
            CHCNetSDK.NET_DVR_Cleanup();
        }

        private void btnCancelView_Click(object sender, EventArgs e)
        {
            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
            {
                MessageBox.Show(CHCNetSDK.NET_DVR_GetLastError().ToString());
            }
            picImg.Image = picView.Image = null;
            m_lRealHandle = -1;
        }
    }
}
