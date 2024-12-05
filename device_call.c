#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <unistd.h>

#define DEVICE_PATH "/dev/mydevice"
#define BUFFER_SIZE 256

int main() {
    int fd;
    char buffer[BUFFER_SIZE];
    ssize_t bytes_read;
    ssize_t bytes_written;

    // Open the device file
    fd = open(DEVICE_PATH, O_RDWR);
    if (fd == -1) {
        perror("open");
        exit(EXIT_FAILURE);
    }

    // Write data to the device
    const char *message = "Hello, device!";
    bytes_written = write(fd, message, strlen(message));
    if (bytes_written == -1) {
        perror("write");
        exit(EXIT_FAILURE);
    }

    // Read data from the device
    bytes_read = read(fd, buffer, BUFFER_SIZE - 1);
    if (bytes_read == -1) {
        perror("read");
        exit(EXIT_FAILURE);
    }

    // Null-terminate the buffer and print the response
    buffer[bytes_read] = '\0';
    printf("Device response: %s\n", buffer);

    // Close the device file
    close(fd);

    return 0;
}
