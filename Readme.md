# Grasshopper 外掛元件安裝說明  
  
1.打開Rhino，在指令的地方輸入GrasshopperDeveloperSettings -> Add Folder ->  選擇檔案Gha、pdb所在的檔案路徑  
(檔案路徑 -> .\MyProject3\MyProject3\bin)    
Gha、pdb檔需要以右鍵 -> 內容 > 解除封鎖  
2.設定完成後，重啟Rhino，打開Grashopper  
3.在IN.LA的元件裡面會有Winform  
4.把Winform元件拖入Grasshopper  
5.點選Winform元件，右鍵點選Set Boolean -> 設定True    
6.設定為True後，會開啟WPF介面程式  
7.Import File 匯入Point.3dm (檔案路徑 -> .\MyProject3\3dm file)  
8.點選PickMode，可在Rhino上，選擇Point (需要先點選一個點之後，才能一次選擇全部的Point)  
9.Point選取結束後，可在WPF介面上的UR1 xyz coordinate的下拉式選單中出現X、Y、Z的所有點資訊  
10.點選Set可把所有的Point資訊，存成CSV檔  
  
# PickMode、Save按鈕說明  
1.點選Rhino上的點，然後輸入u1,u2,u3,ur1,ur2,ur3的資料  
2.輸入完成後，按下Save按鈕，會出現儲存完成的提示視窗(MessageBox)  
3.每次選點後，按下Save時，會把之前儲存成功的資料保留下來  
  
# Set按鈕說明  
1.按下Set按鈕會匯出成CSV的檔案格式，並儲存所有資訊  
  
# 介面程式開發說明  
1.需安裝Visual Studio 2019 、 Rhino 6.0  
2.介面所在位置 -> .\MyProject3\View\MainWindow.xaml  
3.介面程式所在位置 -> .\MyProject3\View\MainWindow.xaml.cs  
  
# 待修正問題  
1.bc選點編號  
2.圖片建議不要使用絕對路徑    
  
# 待新增功能    
1.在Point上新增Sample  
