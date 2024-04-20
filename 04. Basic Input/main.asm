SYS_WRITE EQU 1
SYS_EXIT EQU 60

STDOUT_FILENO EQU 1

NULL EQU 0x00

USER_NAME_MAX_LEN EQU 64

SECTION .data
	prompt_msg DB "What is your name?", 0x0D, 0x0A, NULL
	prompt_len EQU $ - prompt_msg
	hello_msg DB 0x0D, 0x0A, "Hello "
	hello_len EQU $ - hello_msg
	hello_end_msg DB "!", 0x0D, 0x0A
	hello_end_len EQU $ - hello_end_msg

SECTION .bss
	user_input RESB USER_NAME_MAX_LEN

SECTION .text
	GLOBAL _start

_start:
	MOV RAX, SYS_WRITE
	MOV RDI, STDOUT_FILENO
	MOV RSI, prompt_msg
	MOV RDX, prompt_len
	SYSCALL

	XOR RAX, RAX
	XOR RDI, RDI
	MOV RSI, user_input
	MOV RDX, USER_NAME_MAX_LEN
	SYSCALL

	MOV RAX, SYS_WRITE
	MOV RDI, STDOUT_FILENO
	MOV RSI, hello_msg
	MOV RDX, hello_len
	SYSCALL

	MOV RCX, USER_NAME_MAX_LEN
	MOV RSI, user_input

search_loop:
	CMP BYTE [RSI], 0x0A
	JE found_line_feed
	INC RSI
	LOOP search_loop
	JMP end_search_loop

found_line_feed:
	MOV BYTE[RSI], NULL
	JMP end_search_loop

end_search_loop:
	MOV RAX, SYS_WRITE
	MOV RDI, STDOUT_FILENO
	MOV RSI, user_input
	MOV RDX, USER_NAME_MAX_LEN
	SYSCALL

	MOV RAX, SYS_WRITE
	MOV RDI, STDOUT_FILENO
	MOV RSI, hello_end_msg
	MOV RDX, hello_end_len
	SYSCALL

	MOV RAX, SYS_EXIT
	XOR RDI, RDI
	SYSCALL

