import heapq

class Request:
    def __init__(self, name: str, priority: int, seq: int):
        self.name = name
        self.priority = priority
        self.seq = seq

    def __lt__(self, other):
        return self.priority < other.priority

incoming = [
    Request("Оновити підпис у листі", 3, 1),
    Request("Сервер не відповідає", 1, 2),
    Request("Не друкує принтер", 2, 3),
    Request("Не працює термінал оплати", 1, 4),
    Request("Змінити шпалери", 3, 5),
]

late = Request("Відвалився інтернет у відділі", 1, 6)

def processAll(incoming):
    heap = []
    for req in incoming:
        heapq.heappush(heap, (req.priority, id(req), req))
    
    count = 1
    while heap:
        p, _, req = heapq.heappop(heap)
        print(f"{count}. {req.name} | Пріоритет: {req.priority} | seq: {req.seq}")
        count += 1

def processStable(incoming):
    heap = []
    for req in incoming:
        heapq.heappush(heap, (req.priority, req.seq, req))
    
    count = 1
    while heap:
        p, s, req = heapq.heappop(heap)
        print(f"{count}. {req.name} | Пріоритет: {req.priority} | seq: {req.seq}")
        count += 1

def processWithLate(incoming, late):
    heap = []
    for req in incoming:
        heapq.heappush(heap, (req.priority, req.seq, req))
    
    count = 1
    for _ in range(2):
        if heap:
            p, s, req = heapq.heappop(heap)
            print(f"{count}. {req.name} | Пріоритет: {req.priority} | seq: {req.seq}")
            count += 1
            
    heapq.heappush(heap, (late.priority, late.seq, late))
    
    while heap:
        p, s, req = heapq.heappop(heap)
        print(f"{count}. {req.name} | Пріоритет: {req.priority} | seq: {req.seq}")
        count += 1

if __name__ == "__main__":
    print("=== Задача 1 ===")
    processAll(incoming)
    print("\n=== Задача 2 ===")
    processStable(incoming)
    print("\n=== Задача 3 ===")
    processWithLate(incoming, late)