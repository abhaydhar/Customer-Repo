#include <sqlite3.h>
#include <stdio.h>

int main() {
    sqlite3 *db;
    char *err_msg = 0;

    int rc = sqlite3_open("test.db", &db);

    if (rc != SQLITE_OK) {
        fprintf(stderr, "Cannot open database: %s\n", sqlite3_errmsg(db));
        sqlite3_close(db);
        return 1;
    }

    sqlite3_stmt *res;
    const char *sql = "SELECT * FROM Users";

    rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);

    if (rc != SQLITE_OK) {
        fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
        return 1;
    }

    while ((rc = sqlite3_step(res)) == SQLITE_ROW) {
        int id = sqlite3_column_int(res, 0);
        const unsigned char *name = sqlite3_column_text(res, 1);
        int age = sqlite3_column_int(res, 2);

        printf("%d %s %d\n", id, name, age);
    }

    if (rc != SQLITE_DONE) {
        fprintf(stderr, "Execution failed: %s\n", sqlite3_errmsg(db));
    } else {
        fprintf(stdout, "Operation done successfully\n");
    }

    sqlite3_finalize(res);
    sqlite3_close(db);

    return 0;
}
