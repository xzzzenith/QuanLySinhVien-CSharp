using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n;
        while (true)
        {
            Console.Write("Nhập số lượng sinh viên (n > 0): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                break;
            Console.WriteLine("Số lượng không hợp lệ. Vui lòng nhập lại!");
        }

        string[] hoTen = new string[n];
        double[] diem = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSinh viên thứ {i + 1}:");
            Console.Write("Họ và tên: ");
            hoTen[i] = Console.ReadLine() ?? "";

            while (true)
            {
                Console.Write("Điểm: ");
                if (double.TryParse(Console.ReadLine(), out diem[i]) && diem[i] >= 0 && diem[i] <= 10)
                    break;
                Console.WriteLine("Điểm không hợp lệ. Vui lòng nhập từ 0 đến 10!");
            }
        }

        double tongDiem = 0;
        for (int i = 0; i < n; i++)
            tongDiem += diem[i];
        double diemTrungBinh = tongDiem / n;

        Console.WriteLine($"\nĐiểm trung bình chung của lớp: {diemTrungBinh:F2}");

        double maxDiem = diem[0];
        for (int i = 1; i < n; i++)
            if (diem[i] > maxDiem)
                maxDiem = diem[i];

        Console.WriteLine($"Điểm cao nhất: {maxDiem:F2}");
        Console.Write("Sinh viên có điểm cao nhất: ");
        bool first = true;
        for (int i = 0; i < n; i++)
        {
            if (Math.Abs(diem[i] - maxDiem) < 1e-9)
            {
                if (!first) Console.Write(", ");
                Console.Write(hoTen[i]);
                first = false;
            }
        }
        Console.WriteLine();

        int soLuongDat = 0;
        for (int i = 0; i < n; i++)
            if (diem[i] >= 5.0)
                soLuongDat++;

        Console.WriteLine($"Số sinh viên đạt (>= 5.0): {soLuongDat}");

        Console.WriteLine("\n----- DANH SÁCH SINH VIÊN -----");
        Console.WriteLine("{0,-5}{1,-30}{2,10}", "STT", "Họ và tên", "Điểm");
        Console.WriteLine(new string('-', 45));

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0,-5}{1,-30}{2,10:F2}", i + 1, hoTen[i], diem[i]);
        }

        Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
        Console.ReadKey();
    }
}