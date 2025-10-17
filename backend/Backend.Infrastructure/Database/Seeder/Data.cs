using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Infrastructure.Database.Seeder;

internal static class Data
{
    internal static readonly Dictionary<string, Brand> Brands = new()
    {
         ["intel"] = new Brand { BrandName = "Intel" },
         ["amd"] = new Brand { BrandName = "AMD" },
         ["apple"] = new Brand { BrandName = "Apple" },
         ["nvidia"] = new Brand { BrandName = "Nvidia" },
         ["msi"] = new Brand { BrandName = "MSI" },
         ["asus"] = new Brand { BrandName = "ASUS" },
         ["gigabyte"] = new Brand { BrandName = "Gigabyte" },
         ["palit"] = new Brand { BrandName = "Palit" },
         ["inno3d"] = new Brand { BrandName = "Inno3D" },
         ["corsair"] = new Brand { BrandName = "Corsair" },
         ["gskill"] = new Brand { BrandName = "G.SKILL" },
         ["kingston"] = new Brand { BrandName = "Kingston" },
         ["crucial"] = new Brand { BrandName = "Crucial" },
         ["cooler master"] = new Brand { BrandName = "Cooler Master" },
         ["be quiet!"] = new Brand { BrandName = "be quiet!" },
         ["acer"] = new Brand { BrandName = "Acer" },
         ["samsung"] = new Brand { BrandName = "Samsung" },
         ["asrock"] = new Brand { BrandName = "ASRock" },
         ["benq"] = new Brand { BrandName = "BenQ" },
         ["t-force"] = new Brand { BrandName = "T-Force" },
         ["viper"] = new Brand { BrandName = "Viper" },
         ["xfx"] = new Brand { BrandName = "XFX" },
         ["sapphire"] = new Brand { BrandName = "Sapphire" },
         ["powercolor"] = new Brand { BrandName = "PowerColor" },
    };

    internal static readonly List<Gpu> Gpus =
    [
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 4060 VENTUS 2X BLACK 8G OC",
            ImagePath = "msi_geforce_rtx_4060_ventus_2x_black_8g_oc.png",
            InitialPrice = 328.00,
            DiscountPercentage = 20,
            Quantity = 42,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 1.83, Boost: 2.05),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 160
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 4060 VENTUS 2X White 8G OC",
            ImagePath = "msi_geforce_rtx_4060_ventus_2x_white_8g_oc.png",
            InitialPrice = 328.00,
            DiscountPercentage = 10,
            Quantity = 25,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.85, Boost: 2.10),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 160
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "Dual GeForce RTX 4060 EVO OC Edition 8GB",
            ImagePath = "asus_dual_geforce_rtx_4060_evo_oc_edition_8gb.png",
            InitialPrice = 337.00,
            DiscountPercentage = 25,
            Quantity = 33,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.85, Boost: 2.10),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 165
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 5060 8G SHADOW 2X OC",
            ImagePath = "msi_geforce_rtx_5060_8g_shadow_2x_oc.png",
            InitialPrice = 345.00,
            DiscountPercentage = 20,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.88, Boost: 2.15),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 170
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 5060 8G VENTUS 2X OC",
            ImagePath = "msi_geforce_rtx_5060_8g_ventus_2x_oc.jpg",
            InitialPrice = 345.00,
            DiscountPercentage = 10,
            Quantity = 50,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.90, Boost: 2.18),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 170
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 5060 8G VENTUS 2X OC WHITE",
            ImagePath = "msi_geforce_rtx_5060_8g_ventus_2x_oc_white.jpg",
            InitialPrice = 346.00,
            DiscountPercentage = 40,
            Quantity = 22,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.90, Boost: 2.18),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 170
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 5060 8G GAMING OC",
            ImagePath = "msi_geforce_rtx_5060_8g_gaming_oc.png",
            InitialPrice = 367.00,
            DiscountPercentage = 25,
            Quantity = 40,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.95, Boost: 2.25),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 180
        },
        new()
        {
            Brand = Brands["palit"],
            ModelName = "GeForce RTX 4060 TI Dual 8GB",
            ImagePath = "palit_geforce_rtx_4060_ti_dual_8gb.png",
            InitialPrice = 386.00,
            DiscountPercentage = 20,
            Quantity = 30,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.88, Boost: 2.15),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 180
        },
        new()
        {
            Brand = Brands["inno3d"],
            ModelName = "GeForce RTX 4060 Ti 8GB Twin X2 OC White",
            ImagePath = "inno3d_geforce_rtx_4060_ti_8gb_twin_x2_oc_white.jpg",
            InitialPrice = 456.00,
            DiscountPercentage = 50,
            Quantity = 15,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 1.88, Boost: 2.18),
            BusWidth = BusWidth.Bits128,
            CudaCores = 3072,
            DirectXSupport = 12,
            Tdp = 185
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 5060 Ti 16G SHADOW 2X OC PLUS",
            ImagePath = "msi_geforce_rtx_5060_ti_16g_shadow_2x_oc_plus.png",
            InitialPrice = 484.00,
            DiscountPercentage = 20,
            Quantity = 12,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr7, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.10, Boost: 2.40),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4096,
            DirectXSupport = 12,
            Tdp = 200
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "AMD Radeon RX 6600 Challenger White 8GB",
            ImagePath = "asrock_amd_radeon_rx_6600_challenger_white_8gb.png",
            InitialPrice = 233.00,
            DiscountPercentage = 50,
            Quantity = 22,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz2800),
            ClockSpeed = new ClockSpeed(Base: 1.62, Boost: 1.79),
            BusWidth = BusWidth.Bits128,
            CudaCores = 1792,
            DirectXSupport = 12,
            Tdp = 130
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "AMD RADEON RX 7600 Challenger OC",
            ImagePath = "asrock_amd_radeon_rx_7600_challenger_oc.png",
            InitialPrice = 298.00,
            DiscountPercentage = 20,
            Quantity = 30,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3200),
            ClockSpeed = new ClockSpeed(Base: 1.80, Boost: 2.00),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2304,
            DirectXSupport = 12,
            Tdp = 160
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "AMD RADEON RX 7600 Steel Legend OC",
            ImagePath = "asrock_amd_radeon_rx_7600_steel_legend_oc.png",
            InitialPrice = 327.00,
            DiscountPercentage = 25,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3200),
            ClockSpeed = new ClockSpeed(Base: 1.80, Boost: 2.05),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2304,
            DirectXSupport = 12,
            Tdp = 160
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "AMD Radeon RX 9060 XT Challenger 8GB OC",
            ImagePath = "asrock_amd_radeon_rx_9060_xt_challenger_8gb_oc.png",
            InitialPrice = 353.00,
            DiscountPercentage = 40,
            Quantity = 25,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.00, Boost: 2.30),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2560,
            DirectXSupport = 12,
            Tdp = 180
        },
        new()
        {
            Brand = Brands["xfx"],
            ModelName = "Swift AMD Radeon RX 9060 XT OC Triple Fan Gaming Edition 16GB",
            ImagePath = "xfx_swift_amd_radeon_rx_9060_xt_oc_triple_fan_gaming_edition_16gb.jpg",
            InitialPrice = 443.00,
            DiscountPercentage = 25,
            Quantity = 16,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.00, Boost: 2.30),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4096,
            DirectXSupport = 12,
            Tdp = 220
        },
        new()
        {
            Brand = Brands["xfx"],
            ModelName = "Mercury AMD Radeon RX 9060 XT OC Gaming Edition 16GB",
            ImagePath = "xfx_mercury_amd_radeon_rx_9060_xt_oc_gaming_edition_16gb.jpg",
            InitialPrice = 443.00,
            DiscountPercentage = 25,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.00, Boost: 2.30),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4096,
            DirectXSupport = 12,
            Tdp = 220
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "TUF Gaming Radeon RX 9070 OC Edition 16GB",
            ImagePath = "asus_tuf_gaming_radeon_rx_9070_oc_edition_16gb.png",
            InitialPrice = 746.00,
            DiscountPercentage = 20,
            Quantity = 14,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 2.10, Boost: 2.50),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4608,
            DirectXSupport = 12,
            Tdp = 240
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "AMD Radeon RX 9070 XT Steel Legend 16GB",
            ImagePath = "asrock_amd_radeon_rx_9070_xt_steel_legend_16gb.png",
            InitialPrice = 746.00,
            DiscountPercentage = 20,
            Quantity = 17,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 2.10, Boost: 2.50),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4608,
            DirectXSupport = 12,
            Tdp = 240
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "Prime Radeon RX 9070 OC Edition 16GB",
            ImagePath = "asus_prime_radeon_rx_9070_oc_edition_16gb.png",
            InitialPrice = 754.00,
            DiscountPercentage = 25,
            Quantity = 12,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 2.15, Boost: 2.55),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4608,
            DirectXSupport = 12,
            Tdp = 240
        },
        new()
        {
            Brand = Brands["powercolor"],
            ModelName = "Hellhound Spectral White AMD Radeon RX 9070 XT 16GB",
            ImagePath = "powercolor_hellhound_spectral_white_amd_radeon_rx_9070_xt_16gb.png",
            InitialPrice = 824.00,
            DiscountPercentage = 20,
            Quantity = 15,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3600),
            ClockSpeed = new ClockSpeed(Base: 2.15, Boost: 2.55),
            BusWidth = BusWidth.Bits256,
            CudaCores = 4608,
            DirectXSupport = 12,
            Tdp = 240
        },
        new()
        {
            Brand = Brands["powercolor"],
            ModelName = "AMD Radeon R7 240 4GB 128BIT GDDR5",
            ImagePath = "amd_radeon_r7_240_4gb_128bit_gddr5.png",
            InitialPrice = 111.00,
            DiscountPercentage = 10,
            Quantity = 28,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5, Frequency: Frequency.Mhz1800),
            ClockSpeed = new ClockSpeed(Base: 1.00, Boost: 1.10),
            BusWidth = BusWidth.Bits128,
            CudaCores = 320,
            DirectXSupport = 11,
            Tdp = 75
        },
        new()
        {
            Brand = Brands["xfx"],
            ModelName = "SPEEDSTER SWFT 210 AMD Radeon RX 7600 Core Edition 8GB",
            ImagePath = "xfx_speedster_swft_210_amd_radeon_rx_7600_core_edition_8gb.png",
            InitialPrice = 305.00,
            DiscountPercentage = 15,
            Quantity = 20,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3200),
            ClockSpeed = new ClockSpeed(Base: 1.75, Boost: 1.95),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2304,
            DirectXSupport = 12,
            Tdp = 160
        },
        new()
        {
            Brand = Brands["sapphire"],
            ModelName = "PULSE AMD Radeon RX 9060 XT 8GB",
            ImagePath = "sapphire_pulse_amd_radeon_rx_9060_xt_8gb.png",
            InitialPrice = 369.00,
            DiscountPercentage = 10,
            Quantity = 15,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.00, Boost: 2.30),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2560,
            DirectXSupport = 12,
            Tdp = 180
        },
        new()
        {
            Brand = Brands["powercolor"],
            ModelName = "Reaper AMD Radeon RX 9060 XT 8GB",
            ImagePath = "powercolor_reaper_amd_radeon_rx_9060_xt_8gb.png",
            InitialPrice = 384.00,
            DiscountPercentage = 15,
            Quantity = 14,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.00, Boost: 2.30),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2560,
            DirectXSupport = 12,
            Tdp = 180
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "Radeon RX 9060 XT GAMING OC 8G",
            ImagePath = "gigabyte_radeon_rx_9060_xt_gaming_oc_8g.png",
            InitialPrice = 410.00,
            DiscountPercentage = 20,
            Quantity = 16,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.05, Boost: 2.35),
            BusWidth = BusWidth.Bits128,
            CudaCores = 2560,
            DirectXSupport = 12,
            Tdp = 180
        }
    ];

    internal static readonly List<Cpu> Cpus =
    [
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i3-12100 Tray",
            ImagePath = "intel_core_i312100_tray.jpg",
            InitialPrice = 102.00,
            DiscountPercentage = 50,
            Quantity = 25,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.30, Boost: 4.30),
            Socket = Socket.Lga1700,
            Tdp = 60
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i3-10105",
            ImagePath = "intel_core_i310105_box.jpg",
            InitialPrice = 102.00,
            DiscountPercentage = 8,
            Quantity = 30,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.70, Boost: 4.40),
            Socket = Socket.Lga1200,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i5-13400F",
            ImagePath = "intel_core_i513400f_box.jpg",
            InitialPrice = 138.00,
            DiscountPercentage = 20,
            Quantity = 20,
            Cores = 10,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 2.50, Boost: 4.60),
            Socket = Socket.Lga1700,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 7 5700X",
            ImagePath = "amd_ryzen_7_5700x.jpg",
            InitialPrice = 184.00,
            DiscountPercentage = 15,
            Quantity = 18,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.40, Boost: 4.60),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i5-14600KF",
            ImagePath = "intel_core_i514600kf.jpg",
            InitialPrice = 230.00,
            DiscountPercentage = 25,
            Quantity = 15,
            Cores = 14,
            Threads = 20,
            ClockSpeed = new ClockSpeed(Base: 3.50, Boost: 5.30),
            Socket = Socket.Lga1700,
            Tdp = 125
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i7-14700KF",
            ImagePath = "intel_core_i714700kf.jpg",
            InitialPrice = 353.00,
            DiscountPercentage = 33,
            Quantity = 12,
            Cores = 20,
            Threads = 28,
            ClockSpeed = new ClockSpeed(Base: 3.40, Boost: 5.60),
            Socket = Socket.Lga1700,
            Tdp = 125
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 9 7900X",
            ImagePath = "amd_ryzen_9_7900x.png",
            InitialPrice = 359.00,
            DiscountPercentage = 25,
            Quantity = 10,
            Cores = 12,
            Threads = 24,
            ClockSpeed = new ClockSpeed(Base: 4.70, Boost: 5.60),
            Socket = Socket.Am5,
            Tdp = 170
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 9 9950X",
            ImagePath = "amd_ryzen_9_9950x.jpg",
            InitialPrice = 598.00,
            DiscountPercentage = 40,
            Quantity = 8,
            Cores = 16,
            Threads = 32,
            ClockSpeed = new ClockSpeed(Base: 4.30, Boost: 5.70),
            Socket = Socket.Am5,
            Tdp = 170
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 9 9900X3D",
            ImagePath = "amd_ryzen_9_9900x3d.jpg",
            InitialPrice = 640.00,
            DiscountPercentage = 50,
            Quantity = 5,
            Cores = 12,
            Threads = 24,
            ClockSpeed = new ClockSpeed(Base: 4.40, Boost: 5.60),
            Socket = Socket.Am5,
            Tdp = 120
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core Ultra 9 285K",
            ImagePath = "intel_core_ultra_9_285k.jpg",
            InitialPrice = 640.00,
            DiscountPercentage = 10,
            Quantity = 5,
            Cores = 24,
            Threads = 32,
            ClockSpeed = new ClockSpeed(Base: 3.60, Boost: 5.70),
            Socket = Socket.Lga1700,
            Tdp = 125
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 3 4100",
            ImagePath = "amd_ryzen_3_4100_box.jpg",
            InitialPrice = 56.00,
            DiscountPercentage = 0,
            Quantity = 45,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.80, Boost: 4.00),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 3600",
            ImagePath = "amd_ryzen_5_3600_.png",
            InitialPrice = 61.00,
            DiscountPercentage = 0,
            Quantity = 38,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.60, Boost: 4.20),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i3-12100F",
            ImagePath = "intel_core_i312100f.jpg",
            InitialPrice = 81.00,
            DiscountPercentage = 0,
            Quantity = 41,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.30, Boost: 4.30),
            Socket = Socket.Lga1700,
            Tdp = 60
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 5600",
            ImagePath = "amd_ryzen_5_5600.png",
            InitialPrice = 117.00,
            DiscountPercentage = 0,
            Quantity = 55,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.50, Boost: 4.40),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 5500GT",
            ImagePath = "amd_ryzen_5_5500gt.png",
            InitialPrice = 128.00,
            DiscountPercentage = 0,
            Quantity = 47,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.60, Boost: 4.40),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 7 5700",
            ImagePath = "amd_ryzen_7_5700.png",
            InitialPrice = 138.00,
            DiscountPercentage = 0,
            Quantity = 33,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.70, Boost: 4.60),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 5600GT",
            ImagePath = "amd_ryzen_5_5600gt.png",
            InitialPrice = 143.00,
            DiscountPercentage = 0,
            Quantity = 52,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.60, Boost: 4.40),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i3-13100",
            ImagePath = "intel_core_i313100.jpg",
            InitialPrice = 153.00,
            DiscountPercentage = 0,
            Quantity = 36,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.40, Boost: 4.50),
            Socket = Socket.Lga1700,
            Tdp = 60
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 8400F",
            ImagePath = "amd_ryzen_5_8400f.jpg",
            InitialPrice = 153.00,
            DiscountPercentage = 0,
            Quantity = 39,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.90, Boost: 4.70),
            Socket = Socket.Am5,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i3-14100",
            ImagePath = "intel_core_i314100.png",
            InitialPrice = 163.00,
            DiscountPercentage = 0,
            Quantity = 28,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.50, Boost: 4.70),
            Socket = Socket.Lga1700,
            Tdp = 60
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 7 5700G",
            ImagePath = "amd_ryzen_7_5700g.png",
            InitialPrice = 169.00,
            DiscountPercentage = 0,
            Quantity = 61,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.80, Boost: 4.60),
            Socket = Socket.Am4,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i5-12400",
            ImagePath = "intel_core_i512400.jpg",
            InitialPrice = 194.00,
            DiscountPercentage = 0,
            Quantity = 49,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 2.50, Boost: 4.40),
            Socket = Socket.Lga1700,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["amd"],
            ModelName = "Ryzen 5 7600",
            ImagePath = "amd_ryzen_5_7600_box.png",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = 53,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.80, Boost: 5.10),
            Socket = Socket.Am5,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i5-14400F",
            ImagePath = "intel_core_i514400f.png",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = 57,
            Cores = 10,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 2.50, Boost: 4.70),
            Socket = Socket.Lga1700,
            Tdp = 65
        },
        new()
        {
            Brand = Brands["intel"],
            ModelName = "Core i5-12600K",
            ImagePath = "intel_core_i512600k.jpg",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = 46,
            Cores = 10,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.70, Boost: 4.90),
            Socket = Socket.Lga1700,
            Tdp = 125
        }
    ];
    
    internal static readonly List<Shipping> Shippings =
    [
        new()
        {
            ShippingType = ShippingType.Express,
            Cost = 25,
            Days = 2
        },
        new()
        {
            ShippingType = ShippingType.Standard,
            Cost = 10,
            Days = 5
        },
        new()
        {
            ShippingType = ShippingType.NextDay,
            Cost = 35,
            Days = 1
        },
        new()
        {
            ShippingType = ShippingType.SameDay,
            Cost = 50,
            Days = 0
        }
    ];
    
    internal static readonly Dictionary<string, Country> Countries = new()
    {
        ["bulgaria"] = new Country { CountryName = "Bulgaria" },
        ["austria"] = new Country { CountryName = "Austria" },
        ["belgium"] = new Country { CountryName = "Belgium" },
        ["croatia"] = new Country { CountryName = "Croatia" },
        ["czechia"] = new Country { CountryName = "Czechia" },
        ["denmark"] = new Country { CountryName = "Denmark" },
        ["finland"] = new Country { CountryName = "Finland" },
        ["france"] = new Country { CountryName = "France" },
        ["germany"] = new Country { CountryName = "Germany" },
        ["greece"] = new Country { CountryName = "Greece" },
        ["hungary"] = new Country { CountryName = "Hungary" },
        ["italy"] = new Country { CountryName = "Italy" },
        ["netherlands"] = new Country { CountryName = "Netherlands" },
        ["poland"] = new Country { CountryName = "Poland" },
        ["portugal"] = new Country { CountryName = "Portugal" },
        ["romania"] = new Country { CountryName = "Romania" },
        ["slovakia"] = new Country { CountryName = "Slovakia" },
        ["slovenia"] = new Country { CountryName = "Slovenia" },
        ["spain"] = new Country { CountryName = "Spain" },
        ["sweden"] = new Country { CountryName = "Sweden" },
        ["uk"] = new Country { CountryName = "United Kingdom" },
        ["us"] = new Country { CountryName = "United States" }
    };
    
    internal static readonly List<City> Cities =
    [
        new() { Country = Countries["bulgaria"], CityName = "Sofia" },
        new() { Country = Countries["bulgaria"], CityName = "Plovdiv" },
        new() { Country = Countries["bulgaria"], CityName = "Varna" },
        new() { Country = Countries["austria"], CityName = "Vienna" },
        new() { Country = Countries["austria"], CityName = "Salzburg" },
        new() { Country = Countries["austria"], CityName = "Graz" },
        new() { Country = Countries["belgium"], CityName = "Brussels" },
        new() { Country = Countries["belgium"], CityName = "Antwerp" },
        new() { Country = Countries["belgium"], CityName = "Ghent" },
        new() { Country = Countries["croatia"], CityName = "Zagreb" },
        new() { Country = Countries["croatia"], CityName = "Split" },
        new() { Country = Countries["croatia"], CityName = "Rijeka" },
        new() { Country = Countries["czechia"], CityName = "Prague" },
        new() { Country = Countries["czechia"], CityName = "Brno" },
        new() { Country = Countries["czechia"], CityName = "Ostrava" },
        new() { Country = Countries["denmark"], CityName = "Copenhagen" },
        new() { Country = Countries["denmark"], CityName = "Aarhus" },
        new() { Country = Countries["denmark"], CityName = "Odense" },
        new() { Country = Countries["finland"], CityName = "Helsinki" },
        new() { Country = Countries["finland"], CityName = "Espoo" },
        new() { Country = Countries["finland"], CityName = "Tampere" },
        new() { Country = Countries["france"], CityName = "Paris" },
        new() { Country = Countries["france"], CityName = "Lyon" },
        new() { Country = Countries["france"], CityName = "Marseille" },
        new() { Country = Countries["germany"], CityName = "Berlin" },
        new() { Country = Countries["germany"], CityName = "Munich" },
        new() { Country = Countries["germany"], CityName = "Frankfurt" },
        new() { Country = Countries["greece"], CityName = "Athens" },
        new() { Country = Countries["greece"], CityName = "Thessaloniki" },
        new() { Country = Countries["greece"], CityName = "Patras" },
        new() { Country = Countries["hungary"], CityName = "Budapest" },
        new() { Country = Countries["hungary"], CityName = "Debrecen" },
        new() { Country = Countries["hungary"], CityName = "Szeged" },
        new() { Country = Countries["italy"], CityName = "Rome" },
        new() { Country = Countries["italy"], CityName = "Milan" },
        new() { Country = Countries["italy"], CityName = "Naples" },
        new() { Country = Countries["netherlands"], CityName = "Amsterdam" },
        new() { Country = Countries["netherlands"], CityName = "Rotterdam" },
        new() { Country = Countries["netherlands"], CityName = "The Hague" },
        new() { Country = Countries["poland"], CityName = "Warsaw" },
        new() { Country = Countries["poland"], CityName = "Krakow" },
        new() { Country = Countries["poland"], CityName = "Gdansk" },
        new() { Country = Countries["portugal"], CityName = "Lisbon" },
        new() { Country = Countries["portugal"], CityName = "Porto" },
        new() { Country = Countries["portugal"], CityName = "Coimbra" },
        new() { Country = Countries["romania"], CityName = "Bucharest" },
        new() { Country = Countries["romania"], CityName = "Cluj-Napoca" },
        new() { Country = Countries["romania"], CityName = "Timisoara" },
        new() { Country = Countries["slovakia"], CityName = "Bratislava" },
        new() { Country = Countries["slovakia"], CityName = "Kosice" },
        new() { Country = Countries["slovakia"], CityName = "Presov" },
        new() { Country = Countries["slovenia"], CityName = "Ljubljana" },
        new() { Country = Countries["slovenia"], CityName = "Maribor" },
        new() { Country = Countries["slovenia"], CityName = "Kranj" },
        new() { Country = Countries["spain"], CityName = "Madrid" },
        new() { Country = Countries["spain"], CityName = "Barcelona" },
        new() { Country = Countries["spain"], CityName = "Valencia" },
        new() { Country = Countries["sweden"], CityName = "Stockholm" },
        new() { Country = Countries["sweden"], CityName = "Gothenburg" },
        new() { Country = Countries["sweden"], CityName = "Malmo" },
        new() { Country = Countries["uk"], CityName = "London" },
        new() { Country = Countries["uk"], CityName = "Manchester" },
        new() { Country = Countries["uk"], CityName = "Birmingham" },
        new() { Country = Countries["us"], CityName = "New York" },
        new() { Country = Countries["us"], CityName = "Los Angeles" },
        new() { Country = Countries["us"], CityName = "Chicago" }
    ];
}