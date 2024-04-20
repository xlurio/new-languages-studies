
STDOUT_FILENO equ 1
SYS_WRITE equ 1
SYS_EXIT equ 60

SECTION .data
    message DB "Hello World!", 0x0D, 0x0A
    msg_len EQU $ - message

SECTION .text
	GLOBAL _start

_start:
    MOV RAX, SYS_WRITE
    MOV RDI, STDOUT_FILENO
    MOV RSI, message
    MOV RDX, msg_len
    SYSCALL

    MOV RAX, SYS_EXIT
    XOR RDI, RDI ; Most efficient way of zeroing a register
    SYSCALL

