using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Seeder;

internal static class Data
{
    private static readonly Random Random = new();
    
    internal static readonly Dictionary<string, Brand> Brands = new()
    {
        ["intel"] = new Brand { BrandName = "Intel" },
        ["amd"] = new Brand { BrandName = "AMD" },
        ["msi"] = new Brand { BrandName = "MSI" },
        ["asus"] = new Brand { BrandName = "ASUS" },
        ["gigabyte"] = new Brand { BrandName = "Gigabyte" },
        ["palit"] = new Brand { BrandName = "Palit" },
        ["lg"] = new Brand { BrandName = "LG" },
        ["inno3d"] = new Brand { BrandName = "Inno3D" },
        ["corsair"] = new Brand { BrandName = "Corsair" },
        ["gskill"] = new Brand { BrandName = "G.SKILL" },
        ["crucial"] = new Brand { BrandName = "Crucial" },
        ["acer"] = new Brand { BrandName = "Acer" },
        ["asrock"] = new Brand { BrandName = "ASRock" },
        ["xfx"] = new Brand { BrandName = "XFX" },
        ["sapphire"] = new Brand { BrandName = "Sapphire" },
        ["powercolor"] = new Brand { BrandName = "PowerColor" },
        ["thermaltake"] = new Brand { BrandName = "Thermaltake" },
        ["thermalright"] = new Brand { BrandName = "Thermalright" },
        ["deepcool"] = new Brand { BrandName = "DeepCool" },
        ["adata"] = new Brand { BrandName = "ADATA" },
        ["xpg"] = new Brand { BrandName = "XPG" },
        ["seasonic"] = new Brand { BrandName = "Seasonic" }
    };

    internal static readonly List<Gpu> Gpus =
    [
        new()
        {
            Brand = Brands["msi"],
            ModelName = "GeForce RTX 4060 VENTUS 2X BLACK 8G OC",
            ImagePath = "gpus/msi_geforce_rtx_4060_ventus_2x_black_8g_oc.png",
            InitialPrice = 328.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_4060_ventus_2x_white_8g_oc.png",
            InitialPrice = 328.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asus_dual_geforce_rtx_4060_evo_oc_edition_8gb.png",
            InitialPrice = 337.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_5060_8g_shadow_2x_oc.png",
            InitialPrice = 345.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_5060_8g_ventus_2x_oc.jpg",
            InitialPrice = 345.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_5060_8g_ventus_2x_oc_white.jpg",
            InitialPrice = 346.00,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_5060_8g_gaming_oc.png",
            InitialPrice = 367.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/palit_geforce_rtx_4060_ti_dual_8gb.png",
            InitialPrice = 386.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/inno3d_geforce_rtx_4060_ti_8gb_twin_x2_oc_white.jpg",
            InitialPrice = 456.00,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/msi_geforce_rtx_5060_ti_16g_shadow_2x_oc_plus.png",
            InitialPrice = 484.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asrock_amd_radeon_rx_6600_challenger_white_8gb.png",
            InitialPrice = 233.00,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asrock_amd_radeon_rx_7600_challenger_oc.png",
            InitialPrice = 298.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asrock_amd_radeon_rx_7600_steel_legend_oc.png",
            InitialPrice = 327.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asrock_amd_radeon_rx_9060_xt_challenger_8gb_oc.png",
            InitialPrice = 353.00,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/xfx_swift_amd_radeon_rx_9060_xt_oc_triple_fan_gaming_edition_16gb.jpg",
            InitialPrice = 443.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/xfx_mercury_amd_radeon_rx_9060_xt_oc_gaming_edition_16gb.jpg",
            InitialPrice = 443.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asus_tuf_gaming_radeon_rx_9070_oc_edition_16gb.png",
            InitialPrice = 746.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asrock_amd_radeon_rx_9070_xt_steel_legend_16gb.png",
            InitialPrice = 746.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/asus_prime_radeon_rx_9070_oc_edition_16gb.png",
            InitialPrice = 754.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/powercolor_hellhound_spectral_white_amd_radeon_rx_9070_xt_16gb.png",
            InitialPrice = 824.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/amd_radeon_r7_240_4gb_128bit_gddr5.png",
            InitialPrice = 111.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/xfx_speedster_swft_210_amd_radeon_rx_7600_core_edition_8gb.png",
            InitialPrice = 305.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/sapphire_pulse_amd_radeon_rx_9060_xt_8gb.png",
            InitialPrice = 369.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/powercolor_reaper_amd_radeon_rx_9060_xt_8gb.png",
            InitialPrice = 384.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "gpus/gigabyte_radeon_rx_9060_xt_gaming_oc_8g.png",
            InitialPrice = 410.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i312100_tray.jpg",
            InitialPrice = 102.00,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i310105_box.jpg",
            InitialPrice = 102.00,
            DiscountPercentage = 8,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i513400f_box.jpg",
            InitialPrice = 138.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_7_5700x.jpg",
            InitialPrice = 184.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i514600kf.jpg",
            InitialPrice = 230.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i714700kf.jpg",
            InitialPrice = 353.00,
            DiscountPercentage = 33,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_9_7900x.png",
            InitialPrice = 359.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_9_9950x.jpg",
            InitialPrice = 598.00,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_9_9900x3d.jpg",
            InitialPrice = 640.00,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_ultra_9_285k.jpg",
            InitialPrice = 640.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_3_4100_box.jpg",
            InitialPrice = 56.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_3600_.png",
            InitialPrice = 61.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i312100f.jpg",
            InitialPrice = 81.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_5600.png",
            InitialPrice = 117.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_5500gt.png",
            InitialPrice = 128.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_7_5700.png",
            InitialPrice = 138.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_5600gt.png",
            InitialPrice = 143.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i313100.jpg",
            InitialPrice = 153.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_8400f.jpg",
            InitialPrice = 153.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i314100.png",
            InitialPrice = 163.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_7_5700g.png",
            InitialPrice = 169.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i512400.jpg",
            InitialPrice = 194.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/amd_ryzen_5_7600_box.png",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i514400f.png",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
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
            ImagePath = "cpus/intel_core_i512600k.jpg",
            InitialPrice = 199.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Cores = 10,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.70, Boost: 4.90),
            Socket = Socket.Lga1700,
            Tdp = 125
        }
    ];

    internal static readonly List<Monitor> Monitors =
    [
        new()
        {
            Brand = Brands["acer"],
            ModelName = "EK251QEbi",
            ImagePath = "monitors/acer_ek251qebi.png",
            InitialPrice = 86.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24.5,
            RefreshRate = RefreshRate.Hz100,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.28,
            Brightness = 250,
            ColorSpectre = 72
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "SA243YG0wi",
            ImagePath = "monitors/acer_sa243yg0wi.png",
            InitialPrice = 91.00,
            DiscountPercentage = 42,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 23.8,
            RefreshRate = RefreshRate.Hz120,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 72
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "TUF Gaming VG249Q3A",
            ImagePath = "monitors/asus_tuf_gaming_vg249q3a.png",
            InitialPrice = 112.00,
            DiscountPercentage = 108,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 23.8,
            RefreshRate = RefreshRate.Hz180,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.28,
            Brightness = 250,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro XF240YX1biiph",
            ImagePath = "monitors/acer_nitro_xf240yx1biiph.png",
            InitialPrice = 122.00,
            DiscountPercentage = 33,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 23.8,
            RefreshRate = RefreshRate.Hz200,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "SH272Ebmihux",
            ImagePath = "monitors/acer_sh272ebmihux.png",
            InitialPrice = 128.00,
            DiscountPercentage = 83,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz100,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 250,
            ColorSpectre = 72
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro XF270X1biiph",
            ImagePath = "monitors/acer_nitro_xf270x1biiph.png",
            InitialPrice = 148.00,
            DiscountPercentage = 58,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz165,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 300,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "TUF Gaming VG279QL3A",
            ImagePath = "monitors/asus_tuf_gaming_vg279ql3a.png",
            InitialPrice = 153.00,
            DiscountPercentage = 83,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz180,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 350,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "LG 27TQ615S-PZ",
            ImagePath = "monitors/lg_27tq615spz.jpg",
            InitialPrice = 179.00,
            DiscountPercentage = 17,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz75,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 250,
            ColorSpectre = 72
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Predator XB253QFbmiiprx",
            ImagePath = "monitors/acer_predator_xb253qfbmiiprx.png",
            InitialPrice = 194.00,
            DiscountPercentage = 67,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 25,
            RefreshRate = RefreshRate.Hz240,
            Latency = 0.5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.28,
            Brightness = 400,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro KG272KL1bmiipx",
            ImagePath = "monitors/acer_nitro_kg272kl1bmiipx.png",
            InitialPrice = 214.00,
            DiscountPercentage = 67,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz180,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440, ResolutionType.Qhd),
            PixelSize = 0.23,
            Brightness = 300,
            ColorSpectre = 72
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro VG240YGbip",
            ImagePath = "monitors/acer_nitro_vg240ygbip.png",
            InitialPrice = 97.00,
            DiscountPercentage = 33,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz165,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro KG241YX3bip",
            ImagePath = "monitors/acer_nitro_kg241yx3bip.png",
            InitialPrice = 102.00,
            DiscountPercentage = 8,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz180,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 300,
            ColorSpectre = 95
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro KG251QX0biip",
            ImagePath = "monitors/acer_nitro_kg251qx0biip.png",
            InitialPrice = 107.00,
            DiscountPercentage = 8,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 25,
            RefreshRate = RefreshRate.Hz165,
            Latency = 1,
            Matrix = Matrix.Tn,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.28,
            Brightness = 250,
            ColorSpectre = 90
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro VG240YM3bmiipx",
            ImagePath = "monitors/acer_nitro_vg240ym3bmiipx.png",
            InitialPrice = 123.00,
            DiscountPercentage = 75,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz180,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro VG273bii",
            ImagePath = "monitors/acer_nitro_vg273bii_UMHV3EE001.png",
            InitialPrice = 153.00,
            DiscountPercentage = 83,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz75,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 250,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["asus"],
            ModelName = "TUF Gaming VG27AQA1A",
            ImagePath = "monitors/asus_tuf_gaming_vg27aqa1a.jpg",
            InitialPrice = 210.00,
            DiscountPercentage = 66,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz170,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440, ResolutionType.Qhd),
            PixelSize = 0.23,
            Brightness = 350,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Nitro XZ320QUS3bmiiphx",
            ImagePath = "monitors/acer_nitro_xz320qus3bmiiphx.png",
            InitialPrice = 235.00,
            DiscountPercentage = 116,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 32,
            RefreshRate = RefreshRate.Hz165,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440, ResolutionType.Qhd),
            PixelSize = 0.27,
            Brightness = 300,
            ColorSpectre = 95
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "34WR55QK",
            ImagePath = "monitors/lg_34wr55qk.jpg",
            InitialPrice = 337.00,
            DiscountPercentage = 41,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 34,
            RefreshRate = RefreshRate.Hz100,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3440, 1440, ResolutionType.Qhd),
            PixelSize = 0.23,
            Brightness = 300,
            ColorSpectre = 99
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "24MR400-B",
            ImagePath = "monitors/lg_24mr400b.jpg",
            InitialPrice = 86.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz75,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 98
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "Vero V247YEbiv",
            ImagePath = "monitors/acer_vero_v247yebiv.png",
            InitialPrice = 91.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz75,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 98
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "22MR410-B",
            ImagePath = "monitors/lg_22mr410b.jpg",
            InitialPrice = 91.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 22,
            RefreshRate = RefreshRate.Hz75,
            Latency = 5,
            Matrix = Matrix.Tn,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.25,
            Brightness = 250,
            ColorSpectre = 90
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "KA272E0bi",
            ImagePath = "monitors/acer_ka272e0bi.png",
            InitialPrice = 107.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz75,
            Latency = 4,
            Matrix = Matrix.Va,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 300,
            ColorSpectre = 95
        },
        new()
        {
            Brand = Brands["acer"],
            ModelName = "SH242YEbmihux",
            ImagePath = "monitors/acer_sh242yebmihux.png",
            InitialPrice = 107.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz75,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 97
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "27MR400-B",
            ImagePath = "monitors/lg_27mr400b.jpg",
            InitialPrice = 117.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 27,
            RefreshRate = RefreshRate.Hz75,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.31,
            Brightness = 250,
            ColorSpectre = 98
        },
        new()
        {
            Brand = Brands["lg"],
            ModelName = "24MS550-B",
            ImagePath = "monitors/lg_24ms550b.jpg",
            InitialPrice = 127.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            DisplayDiagonal = 24,
            RefreshRate = RefreshRate.Hz75,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080, ResolutionType.Fhd),
            PixelSize = 0.27,
            Brightness = 250,
            ColorSpectre = 98
        }
    ];

    internal static readonly List<Ram> Rams =
    [
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s Pro OC Gaming White",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_crucial_pro_oc_gaming_white.jpg",
            InitialPrice = 111.03,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s Vengeance White CL36",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_corsair_vengeance_rgb_whiteduplicate.jpg",
            InitialPrice = 111.03,
            DiscountPercentage = 33,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR4 3600MHz Vengeance RGB PRO SL White",
            ImagePath = "rams/32gb_2x16gb_ddr4_3600mhz_corsair_vengeance_rgb_pro_sl_white.png",
            InitialPrice = 170.51,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "64GB (2x32GB) DDR5 6000MHz Vengeance RGB Black",
            ImagePath = "rams/64gb_2x32gb_ddr5_6000mhz_corsair_vengeance_rgb_black.jpg",
            InitialPrice = 257.34,
            DiscountPercentage = 41,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(64, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["gskill"],
            ModelName = "96GB (2x48GB) DDR5 6000 MT/s Ripjaws M5 Neo RGB Black",
            ImagePath = "rams/96gb_2x48gb_ddr5_6000_mts_gskill_ripjaws_m5_neo_rgb_black.png",
            InitialPrice = 410.77,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(96, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["gskill"],
            ModelName = "8GB DDR4 3200 MT/s AEGIS",
            ImagePath = "rams/8gb_ddr4_3200mhz_gskill_aegis.png",
            InitialPrice = 7.49,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18"
        },
        new()
        {
            Brand = Brands["gskill"],
            ModelName = "8GB DDR4 2400 MT/s Value",
            ImagePath = "rams/8gb_ddr4_2400_mts_gskill_value.png",
            InitialPrice = 7.49,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz2400),
            Timing = "15-15-15"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "16GB DDR5 6000 MT/s CL36 VENGEANCE Cool Grey",
            ImagePath = "rams/16gb_ddr5_6000_mts_cl36_corsair_vengeance_cool_grey.png",
            InitialPrice = 65.38,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(16, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["gskill"],
            ModelName = "32GB (2x16GB) DDR4 3200 MT/s AEGIS",
            ImagePath = "rams/32gb_2x16gb_ddr4_3200mhz_gskill_aegis.jpg",
            InitialPrice = 86.09,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18"
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s Pro OC Gaming Black",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_crucial_pro_oc_gaming_black.png",
            InitialPrice = 106.53,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "16GB (2x8GB) DDR4 3600MT/s Vengeance RGB PRO SL",
            ImagePath = "rams/16gb_2x8gb_ddr4_3600mhz_corsair_vengeance_rgb_pro_sl.png",
            InitialPrice = 121.51,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s CL38 Vengeance Black",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_cl38_corsair_vengeance_black.png",
            InitialPrice = 124.40,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "38-38-38"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s VENGEANCE Gray",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_corsair_vengeance_gray.png",
            InitialPrice = 124.40,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s CL36 Vengeance Black",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_cl36_corsair_vengeance_black.png",
            InitialPrice = 124.40,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s CL36 Vengeance RGB Black",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_corsair_vengeance_rgb_black.png",
            InitialPrice = 134.42,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s CL36 Vengeance RGB Black",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_cl36_corsair_vengeance_rgb_black.png",
            InitialPrice = 139.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s CL36 VENGEANCE White",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_cl36_corsair_vengeance_white.png",
            InitialPrice = 139.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 5200 MT/s Vengeance",
            ImagePath = "rams/32gb_2x16gb_ddr5_5200mhz_corsair_vengeance.png",
            InitialPrice = 144.77,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz5200),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR4 3200 MT/s Vengeance RGB RS",
            ImagePath = "rams/32gb_2x_16gb_ddr4_3200mhz_corsair_vengeance_rgb_rs.png",
            InitialPrice = 144.77,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 5200 MT/s Vengeance Cool Grey",
            ImagePath = "rams/32gb_2x16gb_ddr5_5200_mts_corsair_vengeance_cool_grey.jpg",
            InitialPrice = 144.77,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz5200),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s CL32 VENGEANCE White",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_cl32_corsair_vengeance_white.png",
            InitialPrice = 159.24,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "32-32-32"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6000 MT/s Vengeance RGB CL36",
            ImagePath = "rams/32gb_2x16gb_ddr5_6000_mts_corsair_vengeance_rgb_cl36.png",
            InitialPrice = 168.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6000),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s VENGEANCE RGB Grey",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_corsair_vengeance_rgb_gray.png",
            InitialPrice = 182.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "36-36-36"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR4 3600 MT/s Vengeance LPX",
            ImagePath = "rams/32gb_2x16gb_ddr4_3600mhz_corsair_vengeance_lpx.png",
            InitialPrice = 182.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22"
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "32GB (2x16GB) DDR5 6400 MT/s CL32 VENGEANCE RGB Grey",
            ImagePath = "rams/32gb_2x16gb_ddr5_6400_mts_cl32_corsair_vengeance_rgb_grey",
            InitialPrice = 232.69,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Memory = new Memory(32, MemoryType.Ddr5, Frequency.Mhz6400),
            Timing = "32-32-32"
        }
    ];

    internal static readonly List<Motherboard> Motherboards =
    [
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "A620AM Pro-A WiFi",
            ImagePath = "motherboards/asrock_a620am_proa_wifi.png",
            InitialPrice = 112.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "A620",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760M D3HP",
            ImagePath = "motherboards/gigabyte_b760m_d3hp.png",
            InitialPrice = 112.00,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "PRO B760M-P",
            ImagePath = "motherboards/msi_pro_b760mp.png",
            InitialPrice = 112.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["sapphire"],
            ModelName = "B650M-E",
            ImagePath = "motherboards/sapphire_b650me.jpg",
            InitialPrice = 112.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B650",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B850M-X R2.0",
            ImagePath = "motherboards/asrock_b850mx_r20.png",
            InitialPrice = 122.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B850",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760M D3HP WIFI6",
            ImagePath = "motherboards/gigabyte_b760m_d3hp_wifi6.png",
            InitialPrice = 122.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "MPG B550 GAMING PLUS",
            ImagePath = "motherboards/msi_mpg_b550_gaming_plus.png",
            InitialPrice = 122.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760M DS3H GEN5",
            ImagePath = "motherboards/gigabyte_b760m_ds3h_gen5.png",
            InitialPrice = 122.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B550 EAGLE WIFI6",
            ImagePath = "motherboards/gigabyte_b550_eagle_wifi6.png",
            InitialPrice = 127.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B550 GAMING X V2 (rev. 1.3)",
            ImagePath = "motherboards/gigabyte_b550_gaming_x_v2_rev_13.png",
            InitialPrice = 127.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B860M-X",
            ImagePath = "motherboards/asrock_b860mx.png",
            InitialPrice = 127.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B860",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760M GAMING PLUS WIFI DDR4",
            ImagePath = "motherboards/gigabyte_b760m_gaming_plus_wifi_ddr4.png",
            InitialPrice = 127.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B550M-ITX/ac",
            ImagePath = "motherboards/asrock_b550mitxac.png",
            InitialPrice = 133.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am4,
            FormFactor = FormFactor.MiniItx,
            Chipset = "B550",
            RamSlots = 2,
            PcieSlots = 1
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "PRO B650M-P",
            ImagePath = "motherboards/msi_pro_b650mp.png",
            InitialPrice = 133.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B650",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760 DS3H AX DDR4",
            ImagePath = "motherboards/gigabyte_b760_ds3h_ax.png",
            InitialPrice = 133.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B650M PG Lightning",
            ImagePath = "motherboards/asrock_b650m_pg_lightning.png",
            InitialPrice = 133.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B650",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B550 Pro4",
            ImagePath = "motherboards/asrock_b550_pro4.png",
            InitialPrice = 133.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "PRO B760-P II",
            ImagePath = "motherboards/msi_pro_b760p_ii.png",
            InitialPrice = 133.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760 DS3H GEN5",
            ImagePath = "motherboards/gigabyte_b760_ds3h_gen5.png",
            InitialPrice = 133.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B840M DS3H",
            ImagePath = "motherboards/gigabyte_b840m_ds3h.png",
            InitialPrice = 133.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B840",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B650M D3HP AX",
            ImagePath = "motherboards/gigabyte_b650m_d3hp_ax.png",
            InitialPrice = 138.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B650",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "PRO B760M-A WIFI DDR4",
            ImagePath = "motherboards/msi_pro_b760ma_wifi_ddr4.png",
            InitialPrice = 138.00,
            DiscountPercentage = 20,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B850M Pro-A",
            ImagePath = "motherboards/asrock_b850m_proa.png",
            InitialPrice = 138.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Am5,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B850",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "B760M PRO RS",
            ImagePath = "motherboards/asrock_b760m_pro_rs.png",
            InitialPrice = 138.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        },
        new()
        {
            Brand = Brands["gigabyte"],
            ModelName = "B760 GAMING X DDR4",
            ImagePath = "motherboard/gigabyte_b760_gaming_x_ddr4.png",
            InitialPrice = 138.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.Atx,
            Chipset = "B760",
            RamSlots = 4,
            PcieSlots = 2
        }
    ];

    internal static readonly List<Ssd> Ssds =
    [
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP600 Core XT 1TB",
            ImagePath = "ssds/1tb_ssd_corsair_mp600_core_xt.jpg",
            InitialPrice = 83.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 4950, Write: 4250),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "P310 1TB",
            ImagePath = "ssds/1tb_crucial_p310.jpg",
            InitialPrice = 87.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 3500, Write: 3000),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "T500 1TB",
            ImagePath = "ssds/1tb_crucial_t500.jpg",
            InitialPrice = 101.00,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 5500, Write: 5000),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "P510 1TB",
            ImagePath = "ssds/1tb_crucial_p510.png",
            InitialPrice = 111.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 5600, Write: 5100),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "T700 SSD Gen5 NVMe M.2 1TB",
            ImagePath = "ssds/1tb_crucial_t700_gen5_nvme_m2_ssd.png",
            InitialPrice = 127.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 7000, Write: 6500),
            Interface = StorageInterface.Pcie5,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "P310 2TB",
            ImagePath = "ssds/2tb_crucial_p310.jpg",
            InitialPrice = 133.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 2000,
            OperationSpeed = new OperationSpeed(Read: 3500, Write: 3000),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP700 PRO 1TB",
            ImagePath = "ssds/1tb_corsair_mp700_pro.png",
            InitialPrice = 147.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 7000, Write: 6500),
            Interface = StorageInterface.Pcie4,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP700 PRO 2TB",
            ImagePath = "ssds/2tb_corsair_mp700_pro.png",
            InitialPrice = 244.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 2000,
            OperationSpeed = new OperationSpeed(Read: 7000, Write: 6500),
            Interface = StorageInterface.Pcie4,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "P310 500GB",
            ImagePath = "ssds/500gb_crucial_p310.png",
            InitialPrice = 60.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 500,
            OperationSpeed = new OperationSpeed(Read: 3500, Write: 3000),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP700 ELITE 1TB",
            ImagePath = "ssds/1tb_corsair_mp700_elite.png",
            InitialPrice = 141.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 7000, Write: 6500),
            Interface = StorageInterface.Pcie4,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP600 CORE XT rev 2.0 2TB",
            ImagePath = "ssds/2tb_corsair_mp600_core_xt_rev_20.jpg",
            InitialPrice = 157.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 2000,
            OperationSpeed = new OperationSpeed(Read: 4950, Write: 4250),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP600 PRO LPX 2TB",
            ImagePath = "ssds/2tb_ssd_corsair_mp600_pro_lpx.png",
            InitialPrice = 184.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 2000,
            OperationSpeed = new OperationSpeed(Read: 5000, Write: 4500),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "P510 2TB",
            ImagePath = "ssds/2tb_crucial_p510.png",
            InitialPrice = 198.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 2000,
            OperationSpeed = new OperationSpeed(Read: 5600, Write: 5100),
            Interface = StorageInterface.Nvme,
        },
        new()
        {
            Brand = Brands["crucial"],
            ModelName = "T710 1TB",
            ImagePath = "ssds/1tb_crucial_t710.png",
            InitialPrice = 218.00,
            DiscountPercentage = 0,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 1000,
            OperationSpeed = new OperationSpeed(Read: 7000, Write: 6500),
            Interface = StorageInterface.Pcie5,
        },
        new()
        {
            Brand = Brands["corsair"],
            ModelName = "MP600 CORE XT 4TB",
            ImagePath = "ssds/4tb_corsair_mp600_core_xt.png",
            InitialPrice = 331.00,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
            CapacityInGb = 4000,
            OperationSpeed = new OperationSpeed(Read: 5500, Write: 4400),
            Interface = StorageInterface.Pcie4
        }
    ];

    internal static readonly List<PowerSupply> PowerSupplies =
    [
        new()
        {
            Brand = Brands["msi"],
            ModelName = "MAG A650BN 650W Bronze",
            ImagePath = "power-supplies/msi_mag_a650bn.png",
            InitialPrice = 50.80,
            DiscountPercentage = 40,
            Quantity = GetRandomQuantity(),
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.None
        },
        new()
        {
            Brand = Brands["xpg"],
            ModelName = "PYLON 650B",
            ImagePath = "power-supplies/adata_xpg_pylon_650b.png",
            InitialPrice = 61.00,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.None
        },
        new()
        {
            Brand = Brands["deepcool"],
            ModelName = "PK750D 750W Bronze",
            ImagePath = "power-supplies/deepcool_pk750d_750w.jpg",
            InitialPrice = 61.00,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.None
        },
        new()
        {
            Brand = Brands["thermalright"],
            ModelName = "TB-650S ATX 3.0",
            ImagePath = "power-supplies/thermalright_tb650s.jpg",
            InitialPrice = 66.10,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 87,
            Modularity = Modularity.None
        },
        new()
        {
            Brand = Brands["xpg"],
            ModelName = "PYLON 750B",
            ImagePath = "power-supplies/adata_xpg_pylon_750b.png",
            InitialPrice = 66.10,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 87,
            Modularity = Modularity.None
        },
        new()
        {
            Brand = Brands["deepcool"],
            ModelName = "PL750D ATX 3.0",
            ImagePath = "power-supplies/deepcool_pl750d_atx_30.png",
            InitialPrice = 81.35,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 88,
            Modularity = Modularity.Semi
        },
        new()
        {
            Brand = Brands["msi"],
            ModelName = "MAG A750GN PCIE5 ATX 3.1",
            ImagePath = "power-supplies/msi_mag_a750gn_pcie5_atx_31.png",
            InitialPrice = 86.45,
            DiscountPercentage = 10,
            Quantity = GetRandomQuantity(),
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 90,
            Modularity = Modularity.Semi
        },
        new()
        {
            Brand = Brands["seasonic"],
            ModelName = "CORE GX-750 ATX 3.1",
            ImagePath = "power-supplies/seasonic_core_gx750_atx_31.png",
            InitialPrice = 101.40,
            DiscountPercentage = 25,
            Quantity = GetRandomQuantity(),
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 92,
            Modularity = Modularity.Full
        },
        new()
        {
            Brand = Brands["asrock"],
            ModelName = "CL-850G ATX 3.1",
            ImagePath = "power-supplies/asrock_cl850g_atx_31.png",
            InitialPrice = 106.35,
            DiscountPercentage = 15,
            Quantity = GetRandomQuantity(),
            Wattage = 850,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 90,
            Modularity = Modularity.Full
        },
        new()
        {
            Brand = Brands["thermaltake"],
            ModelName = "Toughpower GF1 1200W - TT Premium Edition",
            ImagePath = "power-supplies/thermaltake_toughpower_gf1_1200w_tt_premium_edition.jpg",
            InitialPrice = 177.95,
            DiscountPercentage = 50,
            Quantity = GetRandomQuantity(),
            Wattage = 1200,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 94,
            Modularity = Modularity.Full
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

    private static int GetRandomQuantity() => Random.Next(10, 51);
}