# Models

    ###
    CourseNumber {
      courseNumber: int,
      GetCourseNumber: () => int
    }

###

    GroupName {
      groupName: string,
      GetGroupName: () => string
    }

    # 1й символ - из списка
    # 2й символ - [3, 4, 5] = [бакалавр, магистр, специалитет]
    # 3й символ - CourseNumber, [1..5]
    для студентов [2..5] курсов 3 цифры [1..10] - номер группы
    для студентов 1 курса 2 цифры
    # последний символ? - [c], не ебу что означает (не обязателен)

# Entities

    Group {
      groupName: GroupName,
    }

###

    Student {
      id: int,
      group: GroupName,
      courseNumber: CourseNumber,
    }

# Service

    IsuService {
      groups: Map<groupName, Group>,
      students: Map<id, Student>,
    }
