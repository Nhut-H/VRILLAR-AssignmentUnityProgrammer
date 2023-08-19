# VRILLAR-AssignmentUnityProgrammer
VRILLAR VIETNAM BÀI TEST PHỎNG VẤN CHO VỊ TRÍ LẬP TRÌNH VIÊN UNITY/INTERVIEW ASSIGNMENT FOR THE POSITION OF UNITY PROGRAMMER
-------------------------------------------------------------------------------------------------------------------------------------------
Mô tả cụ thể nội dung và cách triển khai (Description)
-------------------------------------------------------------------------------------------------------------------------------------------
A: Chức năng UserInput:
  - Nhập vào vĩ độ, kinh độ, ngày tháng, thời gian trong ngày
  - Vĩ độ và kinh độ: dùng để tính toán vị trí của mặt trời chiếu xuống vật hình trụ
      + Giả định trục Y tương ứng vĩ độ (Lattitude), trục X tương ứng kinh độ (Longitude).
      + Khai báo: float alpha = Mathf.ArcTan2(Lattitude, Longitude)
      + Định vị vị trí mặt trời: Sun.transform.rotation.y = alpha;
  - Thời gian: dùng để tính toán góc chiếu tương ứng từ mặt trời xuống vật hình trụ, vị trí bóng đổ trên mặt đất.
      + Giải thích: một ngày có 24h tương ứng 360 độ => 1h tương ứng 15 độ
      + Giả định vị trí bắt đầu ngày mới vào lúc 06:00 AM, thời điểm mặt trời sẽ nằm ở đường chân trời.
      + Mỗi giờ trôi qua, mặt trời sẽ lên cao 1 vị trí với góc lệch +15 độ so với ban đầu.
        Tương ứng: 06h00 = 0độ, 07h00 = 15độ, ... 00h00 = 270 độ và tiếp tục trở lại ngày mới với 05h59p = 0 độ
-------------------------------------------------------------------------------------------------------------------------------------------
B: Chức năng AutoTime:
  - Vị trí mặt trời cố định.
  - Thời gian tăng dần với tốc độ x500 lần để mô phỏng quá trình rọi bóng của vật hình trụ.
