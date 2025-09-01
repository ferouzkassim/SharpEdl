namespace sharpEdl
{
    public enum Command : ulong
    {
        SAHARA_HELLO_REQ = 0x1,
        SAHARA_HELLO_RSP = 0x2,
        SAHARA_READ_DATA = 0x3,
        SAHARA_END_TRANSFER = 0x4,
        SAHARA_DONE_REQ = 0x5,
        SAHARA_DONE_RSP = 0x6,
        SAHARA_RESET_REQ = 0x7,
        SAHARA_RESET_RSP = 0x8,
        SAHARA_MEMORY_DEBUG = 0x9,
        SAHARA_MEMORY_READ = 0xA,
        SAHARA_CMD_READY = 0xB,
        SAHARA_SWITCH_MODE = 0xC,
        SAHARA_EXECUTE_REQ = 0xD,
        SAHARA_EXECUTE_RSP = 0xE,
        SAHARA_EXECUTE_DATA = 0xF,
        SAHARA_64BIT_MEMORY_DEBUG = 0x10,
        SAHARA_64BIT_MEMORY_READ = 0x11,
        SAHARA_64BIT_MEMORY_READ_DATA = 0x12,
        SAHARA_RESET_STATE_MACHINE_ID = 0x13
    }
}