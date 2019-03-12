# -*- coding: utf-8 -*-
import sys
import urllib.request
import webbrowser, os


def main():
    arg1 = sys.argv[1]  # read args
    arg2 = sys.argv[2]

    path = '/home/feanor_d/Документы/lab1'
    urllib.request.urlretrieve('http://mail.univ.net.ua/manual.txt', path + '/test.txt')  # retreive page

    file = open(path + '/test.txt')  # read page and search for keyword
    text = file.readlines()
    print(text)

    f = open(path + '/ManualLight.txt', 'w')
    f.close()

    with open(path + "/ManualLight.txt", 'r+') as file_handler:
        for i in range(0, len(text) - 1):
            if (text[i].startswith('if') or text[i].startswith('If') or text[i].find(arg1) != -1):
                file_handler.write('\n')
            elif (text[i].find('chip') != -1):
                file_handler.write(arg2 + '\n')
            else:
                file_handler.write(text[i] + '\n')


main()  # entry point